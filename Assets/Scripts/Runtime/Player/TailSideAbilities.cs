using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxy.Flipside
{
    public class TailSideAbilities : BaseSideAbilities
    {

        [SerializeField] private BaseTailBehaviour tailBehaviour;
        [SerializeField] private float jumpForce = 1.5f;
        
        // Start is called before the first frame update
        void Start()
        {
            base.Init();
            sideUpAbilities.Add(KeyCode.F, SideUpSlap);
            sideDownAbilities.Add(KeyCode.Space, SideDownSlap);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SideUpSlap()
        {
            // todo: Attack with tail
            Debug.Log("Tail: Side Up Slap!");
            if (tailBehaviour) tailBehaviour.Slap(this);
        }

        void SideDownSlap()
        {
            // todo: Was macht der Schweif eigentlich?
            Debug.Log("Tail: Side Down Slap!");
            abilityActive = true;
            playerBehaviour.PlayerRb.velocity = new Vector3(playerBehaviour.PlayerRb.velocity.x, 0.0f, playerBehaviour.PlayerRb.velocity.z);
            playerBehaviour.PlayerRb.AddForce(playerBehaviour.transform.up * jumpForce, ForceMode.Acceleration);
        }

        private void OnCollisionEnter(Collision other)
        {
            abilityActive = false;
        }
    }
}