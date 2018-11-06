using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	private Rigidbody _rigit;
	private bool _posture_control;

	// Use this for initialization
	void Start () {
		_rigit = gameObject.GetComponent<Rigidbody> ();
		_posture_control = true;
	}
	
	// Update is called once per frame
	void Update () {
		if ( _posture_control ) {
			transform.rotation = Quaternion.LookRotation(_rigit.velocity.normalized);
		}
	}

	private void OnCollisionEnter(Collision collision) {
		_posture_control = false;
	}
}
