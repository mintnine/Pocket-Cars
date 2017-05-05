using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed;
	[SerializeField]
	private float revspeed;
	[SerializeField]
	private float topspeed;
	[SerializeField]
	private float rotspeed;
	[SerializeField]
	private float acceleration;
	[SerializeField]
	[Range(0f,1f)]
	private float decelrate;

	private Rigidbody rgbd; 


	// Use this for initialization
	void Start () {
		rgbd = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		//mode keys
		if (Input.GetKey (KeyCode.W)) {
			Accelerate ();
			rgbd.velocity = transform.forward * speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			if (speed <= 0) {
				rgbd.velocity = -transform.forward * revspeed;
			}
		}

		if (Input.GetKey (KeyCode.A)) {
			if (IsMoving()) {
				transform.Rotate (0f, -rotspeed, 0f);
			}
		}

		if (Input.GetKey (KeyCode.D)) {
			if (IsMoving()) {
				transform.Rotate (0f, rotspeed, 0f);
			}
		}
		//modekeys end

		if (speed > 0) {
			speed -= acceleration * decelrate;
		}

	}

	void Accelerate(){
		if (speed < topspeed) {
			speed += acceleration;
		}
	}

	bool IsMoving(){
		if (rgbd.velocity.x != 0 ||
		    rgbd.velocity.y != 0 ||
		    rgbd.velocity.z != 0) {
			return true;
		}

		return false;
	}



}
