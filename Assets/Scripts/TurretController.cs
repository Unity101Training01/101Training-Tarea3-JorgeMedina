using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] float sphereRadius = 10f;
    [SerializeField] GameObject bullet;
    [SerializeField] float cadence;

    Rigidbody turretRb;
    GameObject player;
    RaycastHit hit;
    
    void Start()
    {
        turretRb =  GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        PlayerOnSight();
    }

    void PlayerOnSight()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < sphereRadius)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;            
            StartCoroutine(InstantiateBullets());
        }
    } 

    IEnumerator InstantiateBullets()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(cadence);
    } 
}
