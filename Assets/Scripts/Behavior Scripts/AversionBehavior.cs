using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Aversion")]
public class AversionBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
	// Do nothing if no neighbors.
	if (context.Count == 0)
	{
	    return Vector2.zero;
	}
	
	// Move away from neighbors that are too close.
	Vector2 averageVector = Vector2.zero;
	int count = 0;
	List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
	foreach (Transform item in filteredContext)
	{
	    if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius)
	    {
		averageVector += (Vector2)(agent.transform.position - item.position);
		count++;
	    }
	}

	if (count > 0)
	{
	    averageVector /= count;
	}

	return averageVector;	
    }
}
