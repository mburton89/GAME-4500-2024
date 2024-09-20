using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    Transform target;
    NavMeshAgent agent;
    public GameObject gutsPrefab;

    void Start()
    {
        target = FindObjectOfType<FPSController>().transform;
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.GameOver();
        }
    }

    void Update()
    {
        ChaseTarget();
    }

    void ChaseTarget()
    {
        agent.destination = target.position;
    }

    public void GiveDamage()
    { 
    
    }

    public void TakeDamage(float damageToTake)
    { 
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            Instantiate(gutsPrefab, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }
}
