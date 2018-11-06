using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {
	[SerializeField] private GameObject _tracker_camera = null;
	[SerializeField] private GameObject _up_camera = null;
	[SerializeField] private GameObject _flont_camera = null;
	[SerializeField] private GameObject _right_camera = null;
	[SerializeField] private GameObject _back_camera = null;
	[SerializeField] private GameObject _goddess_camera = null;
	[SerializeField] private GameObject _shop_camera = null;


	// Use this for initialization
	void Start () {
		CameraAllReset();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown( KeyCode.Alpha1 ) ) {
			CameraAllReset( );
		}

		if ( Input.GetKeyDown( KeyCode.Alpha2 ) ) {
			CameraAllReset( );
			_up_camera.SetActive(true);
		}
		
		if ( Input.GetKeyDown( KeyCode.Alpha3 ) ) {
			CameraAllReset( );
			_flont_camera.SetActive(true);
		}

		if ( Input.GetKeyDown( KeyCode.Alpha4 ) ) {
			CameraAllReset( );
			_right_camera.SetActive(true);
		}

		if ( Input.GetKeyDown( KeyCode.Alpha5 ) ) {
			CameraAllReset( );
			_back_camera.SetActive(true);
		}

		if ( Input.GetKeyDown( KeyCode.Alpha6 ) ) {
			CameraAllReset( );
			_goddess_camera.SetActive(true);
		}

		if ( Input.GetKeyDown( KeyCode.Alpha7 ) ) {
			CameraAllReset( );
			_shop_camera.SetActive(true);
		}
	}

	void CameraAllReset( ) {
		_tracker_camera.SetActive(false);
		_up_camera.SetActive(false);
		_flont_camera.SetActive(false);
		_right_camera.SetActive(false);
		_back_camera.SetActive(false);
		_goddess_camera.SetActive(false);
		_shop_camera.SetActive(false);
	}
}
