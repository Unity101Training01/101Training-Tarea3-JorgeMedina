using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 200f;
    Rigidbody bulletRb;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

        bulletRb.AddForce(transform.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
