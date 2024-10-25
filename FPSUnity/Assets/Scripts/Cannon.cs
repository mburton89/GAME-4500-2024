using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileLaunchSpeed;
    public AudioSource shootSound;
    public int currentAmmoCount;
    public TextMeshProUGUI ammoCountText;

    // Start is called before the first frame update
    void Start()
    {
        ammoCountText.SetText("Ammo: " + currentAmmoCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        
    }

    void Shoot()
    {
        if (currentAmmoCount > 0)
        {
            currentAmmoCount--;
            print("Shoot");
            GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(projectileSpawnPoint.forward * projectileLaunchSpeed);
            shootSound.Play();
            Destroy(newProjectile, 5);
            HUD.Instance.UpdateAmmoUI(currentAmmoCount);
            //TODO Make sound effect
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ammo Pickup")
        {
            Destroy(collision.gameObject);
            currentAmmoCount += 10;
            AmmoSpawner.Instance.SpawnNewAmmoPack();
            HUD.Instance.UpdateAmmoUI(currentAmmoCount);
        }
    }
    

    
}
