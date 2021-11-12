using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 80f;
    [SerializeField] float jumpForce = 10f;

    int doubleJumpCount = 2;
    bool isOnGround = true;
    Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessJump();
    }

    void ProcessMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        playerRb.position += transform.forward * moveY * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationSpeed * moveX * Time.deltaTime);
    }

    void ProcessJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                doubleJumpCount--;
            }
            else if(doubleJumpCount > 0)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                doubleJumpCount--;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJumpCount = 2;
        }
    }
}
