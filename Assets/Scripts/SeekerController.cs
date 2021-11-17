using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxDistance = 100f;
    [SerializeField] float sphereRadius = 1f;

    RaycastHit hit;
    Rigidbody seekerRb;
    GameObject player;

    void Start()
    {
        seekerRb =  GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        PlayerOnRadius();
    }

    void PlayerOnRadius()
    {
        if(Physics.SphereCast(transform.position, sphereRadius, transform.position, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log(hit.collider.name);

            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            seekerRb.AddForce(lookDirection * speed * Time.deltaTime);
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
