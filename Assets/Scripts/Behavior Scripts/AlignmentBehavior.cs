using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
	// Maintain current direction if no neighbors. 
	if (context.Count == 0)
	{
	    return agent.transform.up;
	}

	// Calculate the average of all the neighbor's vectors.
	Vector2 averageVector = Vector2.zero;
	List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
	foreach(Transform item in filteredContext)
	{
	    averageVector += (Vector2)item.transform.up;
	} 
	averageVector /= context.Count;

	return averageVector;
    }
}
