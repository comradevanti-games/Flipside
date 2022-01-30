using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxy.Flipside
{
    public class FaceSideAbilities : BaseSideAbilities
    {

        [SerializeField] [Range(0.0f, 1.0f)] private float gravityScale = 0.1f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private ParticleSystem vfx;

        private Vector3 applyGravity;

        // Start is called before the first frame update
        void Start()
        {
            base.Init();
            sideUpAbilities.Add(KeyCode.B, SideUpBlow);
            sideDownAbilities.Add(KeyCode.Space, SideDownBlow);
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
                vfx.Stop();
            }
        }

        private void FixedUpdate()
        {
            if (!abilityActive || playerBehaviour.grounded) return;

            playerBehaviour.PlayerRb.AddForce(applyGravity, ForceMode.Acceleration);
        }

        void SideDownBlow()
        {
            // todo: Hover logic
            Debug.Log("HOVER");
            vfx.Play();
            playerBehaviour.PlayerRb.useGravity = false;
            abilityActive = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            playerBehaviour.PlayerRb.useGravity = true;
            abilityActive = false;
        }
    }
}