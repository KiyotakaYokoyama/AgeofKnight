using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTarget : MonoBehaviour {

	[SerializeField] Transform _look_target = null;
	[SerializeField] TargetMgr _target_mgr = null;
	private bool _hit = false;

	private void Start( ) {
		_hit = false;
        Quaternion rotate = Quaternion.LookRotation(_look_target.transform.position - transform.position);
        rotate.x = rotate.z = 0;
        transform.rotation = rotate;
	}

	void OnCollisionEnter( Collision collision ) {
		if ( collision.collider.tag != "arrow" ) {
			return;
		}
		gameObject.tag = "wood";
		Collision( );
	}

	public void Collision( ) {
		if ( _hit ) {
			return;
		}
		Destroy( gameObject, 3f );
		_target_mgr.Hitting( );
		_hit = true;
	}
}
