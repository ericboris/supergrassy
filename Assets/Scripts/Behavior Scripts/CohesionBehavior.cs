using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
	// Return zero if no nearby neighbors.
	if (context.Count == 0) 
	{
	    return Vector2.zero;
	}

	// Calculate the averageVector of the neighbor's vectors.
	Vector2 averageVector = Vector2.zero;
	List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
	foreach (Transform item in filteredContext)
	{
	    averageVector += (Vector2)item.position;
	}
	averageVector /= context.Count;

	// Calculate the difference between the agent and the averageVector
	averageVector -= (Vector2)agent.transform.position;
    
	return averageVector;
    }
}
