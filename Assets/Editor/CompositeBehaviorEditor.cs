using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehavior))]
public class CompositeBehaviorEditor : Editor
{
    private FlockBehavior newBehavior;
    
    public override void OnInspectorGUI()
    {
	// Setup the window.
	CompositeBehavior cb = (CompositeBehavior)target;

	EditorGUILayout.BeginHorizontal();

	// Handle when there are no behaviors attached.
	if (cb.behaviors == null || cb.behaviors.Length == 0)
	{
	    EditorGUILayout.HelpBox("No behaviors attached.", MessageType.Warning);
	    EditorGUILayout.EndHorizontal();
	}
	else
	{
	    // Add column titles. 
	    EditorGUILayout.LabelField("Behaviors");
	    EditorGUILayout.LabelField("Weights");

	    EditorGUILayout.EndHorizontal();

	    // Display each behavior entry.
	    for (int i = 0; i < cb.behaviors.Length; i++)
	    {
		EditorGUILayout.BeginHorizontal();

		// Each entry has a behavior object, a weight, and a remove button.
		cb.behaviors[i] = (FlockBehavior)EditorGUILayout.ObjectField(cb.behaviors[i], typeof(FlockBehavior), false);
		cb.weights[i] = EditorGUILayout.Slider(cb.weights[i], 0, 1);

		if (GUILayout.Button("Remove") || cb.behaviors[i] == null)
		{
		    cb = Remove(i, cb);
		}

		EditorGUILayout.EndHorizontal();
	    }
	}
	EditorGUILayout.EndHorizontal();

	// Add new behaviors section.
	EditorGUILayout.BeginHorizontal();
	EditorGUILayout.LabelField("Add behavior...");
	EditorGUILayout.EndHorizontal();

	// Mangage adding new behaviors.
	EditorGUILayout.BeginHorizontal();
	newBehavior = (FlockBehavior)EditorGUILayout.ObjectField(newBehavior, typeof(FlockBehavior), false);
	if (newBehavior != null)
	{
	    cb = Add(newBehavior, cb);
	    newBehavior = null;

	    EditorGUILayout.EndHorizontal();
	}
    }

    // Return the provided composite behavior with the new behavior added.
    private CompositeBehavior Add(FlockBehavior newBehavior, CompositeBehavior cb)
    {
	int oldLength = cb.behaviors.Length;
	int newLength = oldLength + 1;

	FlockBehavior[] newBehaviors = new FlockBehavior[newLength];
	float[] newWeights = new float[newLength];

	for (int i = 0; i < oldLength; i++)
	{
	    newBehaviors[i] = cb.behaviors[i];
	    newWeights[i] = cb.weights[i];
	}

	newBehaviors[oldLength] = newBehavior;
	newWeights[oldLength] = 1;

	cb.behaviors = newBehaviors;
	cb.weights = newWeights;
	
	return cb;
    }

    // Return the provided composite behavior with the behavior and weight
    // at the given index removed.
    private CompositeBehavior Remove(int index, CompositeBehavior cb)
    {
	int oldLength = cb.behaviors.Length;
	int newLength = oldLength - 1;
  
	FlockBehavior[] newBehaviors = new FlockBehavior[newLength];
	float[] newWeights = new float[newLength];

	for (int i = 0, j = 0; i < oldLength; i++)
	{
	    if (i != index)
	    {
		newBehaviors[j] = cb.behaviors[i];
		newWeights[j] = cb.weights[i];
		j++;
	    }
	}

	cb.behaviors = newBehaviors;
	cb.weights = newWeights;

	return cb;
    }
}
