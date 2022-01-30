using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnemy : MonoBehaviour
{
    private ParticleSystem vfx;
    private List<ParticleCollisionEvent> collisionEvents;
    
    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
        vfx = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("COLLIDED!");
        int numCollisionEvents = vfx.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            for (int i = 0; i < numCollisionEvents; i++)
            {
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
        }
    }
}
