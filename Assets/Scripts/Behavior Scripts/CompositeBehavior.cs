using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;
    public float[] weights;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
	// Validate inputs.
	if (behaviors.Length != weights.Length)
	{
	    Debug.LogError("Data mismatch in " + name, this);
	    return Vector2.zero;
	}

	// Let averageVector represent the weighted average vector of the behaviors.
	Vector2 averageVector = Vector2.zero;

	// Calculate the averageVector.
	for (int i = 0; i < behaviors.Length; i++)
	{
	    Vector2 partialVector = behaviors[i].CalculateMove(agent, context, flock) * weights[i];

	    if (partialVector != Vector2.zero)
	    {
		if (partialVector.sqrMagnitude > (weights[i] * weights[i]))
		{
		    partialVector.Normalize();
		    partialVector *= weights[i];
		}

		averageVector += partialVector;
	    }
	}
    
	return averageVector;
    }
}
