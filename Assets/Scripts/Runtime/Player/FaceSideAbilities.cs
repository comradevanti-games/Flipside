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
        private Quaternion vfxRotation;
        private bool blowing;

        // Start is called before the first frame update
        void Start()
        {
            base.Init();
            sideUpAbilities.Add(KeyCode.F, SideUpBlow);
            sideDownAbilities.Add(KeyCode.Space, SideDownBlow);
            applyGravity = gravity * gravityScale * Vector3.up;
            vfxRotation = vfx.transform.rotation;
        }

        void SideUpBlow()
        {
            // todo: block enemies
            Debug.Log("Face: Block Enemy");
            blowing = true;
            abilityActive = true;
            vfx.Play();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                playerBehaviour.PlayerRb.useGravity = true;
                abilityActive = false;
                vfx.Stop();
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                vfx.Stop();
                vfx.transform.rotation = vfxRotation;
                blowing = false;
                abilityActive = false;
            }

            if (blowing)
            {
                Vector3 posToBlow = MouseHelper.Instance.TryGetMousePosition();
                if (posToBlow.Equals(Vector3.negativeInfinity)) return;
                posToBlow.y = Mathf.Max(posToBlow.y, vfx.transform.position.y);
                vfx.transform.LookAt(posToBlow);
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