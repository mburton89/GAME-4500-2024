using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    public float walkingSpeed;
    public float maxHealth;
    float currentHealth;

    public GameObject gutsPrefab;
    public GameObject smallGutsPrefab;

    public Image healthBarFill;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        agent.destination = target.position;
    }

    public void TakeDamage(float damageToGive)
    { 
        currentHealth -= damageToGive;
        Instantiate(smallGutsPrefab, transform.position, Quaternion.identity, null);

        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Instantiate(gutsPrefab, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }

    public void GiveDamage()
    {

    }
}
