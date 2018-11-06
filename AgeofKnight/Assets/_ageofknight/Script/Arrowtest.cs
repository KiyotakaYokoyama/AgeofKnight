using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowtest : MonoBehaviour {
	[SerializeField] TargetMgr _target_mgr = null;
    [SerializeField] Transform arrow_target = null; //Controller (left)
    [SerializeField] Transform arrow_on_hand = null; //Controller (right)
    [SerializeField] SteamVR_TrackedObject arrow_controller = null; //Controller (right)
    [SerializeField] SteamVR_TrackedObject bow_controller = null; //Controller (left)
    [SerializeField] float _speed = 100;
	public GameObject prefab;
	public Rigidbody attachPoint;
	FixedJoint joint;
    
	const ushort DRAW_VIVE_POW = 1000;
	const ushort SHOT_VIVE_POW = 3999;
	float _vive_length = 0;
	float _before_length = 0;
	const float VIVE_LENGTH = 0.1f;

	public bool _pop_arrow { get; private set; }

	private void Awake()
	{
		_pop_arrow = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)arrow_controller.index);
        Vector3 distance = arrow_target.position - arrow_on_hand.position;
        float length = distance.magnitude;
		_pop_arrow = length < 0.15f;
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && length < 0.15f)
		{
			var go = GameObject.Instantiate(prefab);
			go.transform.position = attachPoint.transform.position;

			joint = go.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
			_vive_length = length - VIVE_LENGTH;
			_before_length = length;
		}

		if (joint)
		{
            joint.transform.rotation = Quaternion.LookRotation(distance.normalized);
			joint.transform.position = ( arrow_target.position + arrow_on_hand.position ) / 2;
			
			//バイブレーション
			if ( length > _vive_length ) {
				device.TriggerHapticPulse(DRAW_VIVE_POW);
				SteamVR_Controller.Input((int)bow_controller.index).TriggerHapticPulse(DRAW_VIVE_POW);
				_vive_length += VIVE_LENGTH;
				_before_length = length;
			}

			if ( length - _before_length < -0.1 ) {
				_vive_length = length;
				_before_length = length;
			}


			if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				var go = joint.gameObject;
				var rigidbody = go.GetComponent<Rigidbody>();
				Object.DestroyImmediate(joint);
				joint = null;
				if ( length > 0.2f ) {
					Object.Destroy(go, 5.0f);
					rigidbody.velocity = distance.normalized * _speed;
					_target_mgr.AddArrow( go.AddComponent<Arrow> () );

					//バイブレーション
					device.TriggerHapticPulse(SHOT_VIVE_POW);
					SteamVR_Controller.Input((int)bow_controller.index).TriggerHapticPulse(SHOT_VIVE_POW);

					go.GetComponent<SEPlayer>().shot( );
				} else {
					Object.Destroy(go);
				}
			}
		} else {
			_vive_length = 0;
			_before_length = 0;
		}
	}    
}
