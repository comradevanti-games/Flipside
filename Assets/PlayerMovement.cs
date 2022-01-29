using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float jumpForce = 1.5f;
    [SerializeField] private float velocity = 1.0f;

    private Rigidbody2D playerRB;
    private bool flipped = false;
    public bool grounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 direction = ((Vector3) mousePosition - transform.position).normalized;

        if (Input.GetMouseButtonUp(0) && grounded)
        {
            playerRB.AddForce(new Vector2(direction.x * velocity, direction.y * jumpForce), ForceMode2D.Force);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }
}
