using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Instance variables.
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    
    // Start is called before the first frame update.
    void Start() {
	animator = GetComponent<Animator>();
	myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.
    void Update() {
	change = Vector3.zero;
	change.x = Input.GetAxisRaw("Horizontal");
	change.y = Input.GetAxisRaw("Vertical");
	SetIsMoving();
	SetDirection();
    }

    // Set the isMoving boolean for animations.
    void SetIsMoving() {
	if (change != Vector3.zero) {
	    animator.SetBool("isMoving", true);
	} else {
	    animator.SetBool("isMoving", false);
	}
    }

    // Set the direction components to the current direction.
    void SetDirection() {
	if (change != Vector3.zero) {
	    MoveCharacter();
	    animator.SetFloat("moveX", change.x);
	    animator.SetFloat("moveY", change.y);
	}
    }

    // Adjust the player sprite screen position.
    void MoveCharacter() {
	myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
