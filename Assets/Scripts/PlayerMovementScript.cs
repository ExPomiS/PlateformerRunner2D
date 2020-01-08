using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Vitesse")] public float speed;
    private float _maxSpeed;

    [Header("Saut")] [Range(0.1f, 1f, order = 1)]
    public float jumpMultiplier = 1f;

    [Header("Rigidbody")] public Rigidbody2D playerRb;

    [Header("DétectionSol")] public bool isGrounded;
    public LayerMask GroundLayer;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        _maxSpeed = speed;
        playerRb.AddRelativeForce(new Vector2(speed, 0), ForceMode2D.Impulse);
    }

    void Update()
    {
        //----------------------------------------------------------------------------------
        if (playerRb.velocity.magnitude <= _maxSpeed)
        {
            playerRb.AddRelativeForce(new Vector2(speed, 0), ForceMode2D.Force);
        }

        if (Input.touchCount > 0 && isGrounded)
        {
            playerRb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
        }
        //----------------------------------------------------------------------------------
        RaycastDetection();
    }

    void RaycastDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 0.75f, GroundLayer);
        Debug.DrawRay(this.transform.position, Vector2.down, Color.green);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
