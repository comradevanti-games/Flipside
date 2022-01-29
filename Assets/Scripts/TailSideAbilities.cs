using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailSideAbilities : BaseSideAbilities
{
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
    }

    void SideDownSlap()
    {
        // todo: Was macht der Schweif eigentlich?
        Debug.Log("Tail: Side Down Slap!");
    }
}
