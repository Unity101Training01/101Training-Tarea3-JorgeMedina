using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        if(gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
