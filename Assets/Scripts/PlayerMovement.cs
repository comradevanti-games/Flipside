using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private CoinSide side;

    private Rigidbody playerRB;
    private bool flipped = false;
    private Camera camera;
    public bool grounded = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMousePos = camera.ScreenToWorldPoint(mousePos);
        
        Ray ray = camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Vector3 direction = (worldMousePos - transform.position).normalized;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookAt);
        
            if (Input.GetMouseButtonUp(0) && grounded)
            {
                direction = (hit.point - transform.position).normalized;
                Debug.Log(direction);
                playerRB.AddForce(new Vector3(direction.x * side.Velocity, side.JumpForce, direction.z * side.Velocity),
                    ForceMode.Force);
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        grounded = true;
    }

    private void OnCollisionStay(Collision other)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        grounded = false;
    }
}
