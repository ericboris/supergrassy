using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    // Instance variables.
    public Transform target;
    public float smoothing;
    public Vector2 minCoordinates;
    public Vector2 maxCoordinates;

    // Start is called before the first frame update
    void Start() {
	// Do nothing. 
    }

    // Update is called once per frame
    void LateUpdate() {
	if (transform.position != target.position) {
	    // Get the player position and set the camera depth.
	    Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); 

	    // Constrain the camera to within the scene bounds.
	    targetPosition.x = Mathf.Clamp(targetPosition.x, minCoordinates.x, maxCoordinates.x);
	    targetPosition.y = Mathf.Clamp(targetPosition.y, minCoordinates.y, maxCoordinates.y);
	
	    // Move the camera to the player position.
	    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
	}
    }
}
