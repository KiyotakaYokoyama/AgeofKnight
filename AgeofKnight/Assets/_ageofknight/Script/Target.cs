using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	[SerializeField] int _move_vec = 2;
	[SerializeField] Vector3 MOVE_DIR = new Vector3( 1, 0, 0 );
	[SerializeField] int repetition_time = 180;
	Rigidbody rb = null;
	int _move_time = 0;
	int _rotate_time = 0;
	const int ROTATE_INIT_TIME = 180;

	// Use this for initialization
	void Start( ) {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update( ) {
		if ( _move_time == repetition_time ) {
			rb.velocity = MOVE_DIR * _move_vec;
			_move_vec *= -1;
			_move_time = 0;
		}
		_move_time++;

		if ( rb.angularVelocity != new Vector3( 0, 0, 0 ) ) {
			_rotate_time++;
		}
		if ( _rotate_time > ROTATE_INIT_TIME ) {
			//Quaternion init_q = new Quaternion( 0, 0, 0, 0 );
			rb.angularVelocity = Vector3.zero;
			transform.rotation = Quaternion.Euler( 0, 0, 90 );
			_rotate_time = 0;
		}
	}
}
