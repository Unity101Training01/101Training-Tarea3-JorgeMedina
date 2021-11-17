using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float sphereRadius = 10f;

    RaycastHit hit;
    Rigidbody seekerRb;
    GameObject player;

    void Start()
    {
        seekerRb =  GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        PlayerOnRadius();
    }

    void PlayerOnRadius()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < sphereRadius)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            seekerRb.AddForce(lookDirection * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
