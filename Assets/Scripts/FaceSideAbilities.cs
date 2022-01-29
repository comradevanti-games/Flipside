using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSideAbilities : BaseSideAbilities
{

    [SerializeField][Range(0.0f, 1.0f)] private float gravityScale = 0.1f;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 applyGravity;
    
    // Start is called before the first frame update
    void Start()
    {
        base.Init();
        sideUpAbilities.Add(KeyCode.Mouse0, SideUpBlow);
        sideDownAbilities.Add(KeyCode.Mouse0, SideDownBlow);
        applyGravity = gravity * gravityScale * Vector3.up;
    }

    void SideUpBlow()
    {
        // todo: block enemies
        Debug.Log("Face: Block Enemy");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerBehaviour.PlayerRb.useGravity = true;
            abilityActive = false;
        }
    }

    private void FixedUpdate()
    {
        if (!abilityActive) return;
        
        playerBehaviour.PlayerRb.AddForce(applyGravity, ForceMode.Acceleration);
    }

    void SideDownBlow()
    {
        // todo: Hover logic
        Debug.Log("HOVER");
        playerBehaviour.PlayerRb.useGravity = false;
        abilityActive = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        playerBehaviour.PlayerRb.useGravity = true;
        abilityActive = false;
    }
}
