using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Vitesse")] public float speed;
    private float _maxSpeed;

    [Header("Rigidbody")] public Rigidbody2D playerRb;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        _maxSpeed = speed;
        playerRb.AddRelativeForce(new Vector2(speed, 0), ForceMode2D.Impulse);
    }
    
    void Update()
    {
        if (playerRb.velocity.magnitude <= _maxSpeed)
        {
            playerRb.AddRelativeForce(new Vector2(speed, 0), ForceMode2D.Force);
        }

        if (Input.touchCount > 0)
        {
            playerRb.AddForce(Vector2.up);
        }
    }
}
