using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour {

    // Instance variables.
    public Vector2 cameraTransform;
    public Vector3 playerTransform;
    private CameraMovement cm;

    // Start is called before the first frame update
    void Start() {
	cm = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
	if (other.CompareTag("Player")) {
	    // Slide the camera into the next room.
	    cm.minCoordinates += cameraTransform;
	    cm.maxCoordinates += cameraTransform;
    
	   // Move the player into the next room.
	    other.transform.position += playerTransform; 
	}
    }
}
