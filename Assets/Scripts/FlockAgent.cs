using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    
    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {	     
	agentCollider = GetComponent<Collider2D>();
    }
    
    // Assign the agent flock
    public void Initialize(Flock flock)
    {
	agentFlock = flock;
    }

    // Move the agent by the direction and magnitude of the velocity vector.
    public void Move(Vector2 velocity)
    {
	transform.up = velocity;
	transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
