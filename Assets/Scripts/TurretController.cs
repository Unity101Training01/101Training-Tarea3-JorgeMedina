using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] float sphereRadius = 10f;
    [SerializeField] float maxDistance = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 100f;

    Rigidbody turretRb;
    Rigidbody bulletRb;
    GameObject player;
    RaycastHit hit;
    
    void Start()
    {
        turretRb =  GetComponent<Rigidbody>();
        bulletRb = bullet.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        PlayerOnSight();
    }

    void PlayerOnSight()
    {
        if(Physics.SphereCast(transform.position, sphereRadius, transform.position, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log(hit.collider.name);

            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            
            Instantiate(bullet, transform.position, transform.rotation);
            bulletRb.AddForce(transform.position * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        // Draw a sphere at the SphereCast's position
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * maxDistance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * maxDistance, sphereRadius);
    }    
}
