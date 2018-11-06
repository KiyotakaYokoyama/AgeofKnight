using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMgr : MonoBehaviour {

	[SerializeField] List< GameObject > _pattern = null;
	private List< GameObject > _wave = new List< GameObject >( );
	[SerializeField] private int _wave_count = 0;
	[SerializeField] private int _hit_count = 0;
	private List< Arrow > _arrows = new List< Arrow >( );

	private void Awake( ) {
		Random.InitState( Random.Range( 0, 100 ) );
		_hit_count = 0;
		_wave_count = 0;
	}

	// Use this for initialization
	void Start () {
		foreach ( GameObject obj in _pattern ) {
			for ( int i = 0; i < obj.transform.childCount; i++ ) {
				obj.transform.GetChild( i ).gameObject.SetActive( false );
			}
		}
	}

	public void SetTargets( ) {
		int idx = Random.Range( 0, _pattern.Count );
		GameObject tmp = _pattern[ ( idx ) ];
		Debug.Log( idx );

		_wave.Capacity = tmp.transform.childCount;
		for ( int i = 0; i < tmp.transform.childCount; i++ ) {
			_wave.Add( tmp.transform.GetChild( i ).gameObject );
		}

		foreach ( GameObject obj in _wave ) {
			obj.SetActive( false );
		}
		_wave[ _wave_count ].SetActive( true );

		for ( int i = 0; i < _pattern.Count; i++ ) {
			if ( i != idx ) {
				Destroy( _pattern[ i ] );
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( _wave.Count > 0 && _wave[ _wave_count ].transform.childCount == 0 ) {
			if ( _arrows.Count > 0 ) {
				foreach ( Arrow arrow in _arrows ) {
					if ( arrow )
						Destroy( arrow.gameObject );
				}
				_arrows.Clear( );
			}
			_wave[ ++_wave_count ].SetActive( true );
		}
	}

	public void Hitting( ) {
		_hit_count++;
	}
	
	public int getHitCount( ) {
		return _hit_count;
	}

	public void AddArrow( Arrow arrow ) {
		_arrows.Add( arrow );
	}
}
