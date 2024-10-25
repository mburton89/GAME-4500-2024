using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPickupPrefab;
    public Transform spawnPoint;
    bool isAmmoPickupHere;
    // Start is called before the first frame update

    public static AmmoSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNewAmmoPack()
    {
        StartCoroutine(SpawnNewAmmo());
    }

  

    IEnumerator SpawnNewAmmo()
    {
        yield return new WaitForSeconds(30);
        Instantiate(ammoPickupPrefab, spawnPoint.position, transform.rotation, transform);
    }
}
