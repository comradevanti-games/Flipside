using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxy.Flipside
{
    public class TailSideAbilities : BaseSideAbilities
    {

        [SerializeField] private BaseTailBehaviour tailBehaviour;
        
        // Start is called before the first frame update
        void Start()
        {
            base.Init();
            sideUpAbilities.Add(KeyCode.Mouse0, SideUpSlap);
            sideDownAbilities.Add(KeyCode.Mouse0, SideDownSlap);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SideUpSlap()
        {
            // todo: Attack with tail
            Debug.Log("Tail: Side Up Slap!");
            tailBehaviour.Slap();
        }

        void SideDownSlap()
        {
            // todo: Was macht der Schweif eigentlich?
            Debug.Log("Tail: Side Down Slap!");
        }
    }
}