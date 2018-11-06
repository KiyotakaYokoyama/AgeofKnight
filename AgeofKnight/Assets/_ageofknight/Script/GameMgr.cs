using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {

	enum GameStatus {
		Title,
		Tutorial,
		Start,
		Game,
		Clear
	};
	[SerializeField] GameObject _op_sound = null;
	[SerializeField] GameObject _title = null;
	[SerializeField] GameObject _config = null;
	[SerializeField] GameObject _laser = null;
	[SerializeField] GameObject _tutorial_targets = null;
	[SerializeField] GameObject _game_targets = null;
	[SerializeField] TextMesh _timer = null;
	[SerializeField] GameStatus _status = GameStatus.Title;
	[SerializeField] int GAME_TIME = 60;
	[SerializeField] TargetMgr _target_mgr = null;
	[SerializeField] TextMesh _result = null;
	[SerializeField] private UnityEngine.UI.Text _live_camera_text = null;
	[TextArea(1, 3)][SerializeField] string[ ] _comment = new string[ 5 ];
	private float _game_time;
	private int _hit_num;


	// Use this for initialization
	void Start ( ) {
		_status = GameStatus.Title;
		_game_time = 0;
		_hit_num = 0;
		_game_targets.SetActive( false );
	}

	private void Update( )
	{
		if ( Input.GetKeyDown( KeyCode.Escape ) ) {
			Application.Quit( );
		}
		updateGame( );
		_live_camera_text.text = _status.ToString();
		draw( );
	}	

	private void updateGame( ) {
		switch ( _status ) {
			case GameStatus.Title:
				if( Input.GetKeyDown( KeyCode.Return ) ) {
					_status = GameStatus.Tutorial;
					Destroy(_title);
					Destroy(_op_sound);
				}
				break;
			case GameStatus.Tutorial:
				if( Input.GetKeyDown( KeyCode.Return ) ) {
					_status = GameStatus.Start;
					Destroy( _tutorial_targets );
					_game_targets.SetActive( true );
					Destroy( _config );
					Destroy( _laser );
					_target_mgr.SetTargets( );
					_result.text = "Game Start";
				}
				break;
			case GameStatus.Start:
				_game_time += Time.deltaTime;
				if ( _game_time > 1 ) {
					_result.text = "";
					_status = GameStatus.Game;
					_game_time = 0;
				}
				break;
			case GameStatus.Game:
				_game_time += Time.deltaTime;
				if ( GAME_TIME - _game_time < -1 ) {
					_timer.text = "";
					_hit_num = _target_mgr.getHitCount( );
					Destroy( _game_targets );
					_status = GameStatus.Clear;
				}
				break;
			case GameStatus.Clear:
				if( Input.GetKeyDown( KeyCode.Return ) ) {
					SceneManager.LoadScene(0);
				}
				break;
		}
	}

	private void draw( ) {
		switch ( _status ) {
			case GameStatus.Title:
				break;
			case GameStatus.Tutorial:
				break;
			case GameStatus.Start:
				break;
			case GameStatus.Game:
				_timer.text = ( GAME_TIME - ( int )_game_time ).ToString( );
				break;
			case GameStatus.Clear:
				drawResult( );
				break;
		}
	}

	private void drawResult( ) {
		if ( _hit_num <= 5 ) {
			_result.text = _comment[ 0 ];
		}

		if ( _hit_num >= 6 &&
			 _hit_num <= 15 ) {
			_result.text = _comment[ 1 ];
		}

		if ( _hit_num >= 16 &&
			 _hit_num <= 30 ) {
			_result.text = _comment[ 2 ];
		}

		if ( _hit_num >= 31 &&
			 _hit_num <= 45 ) {
			_result.text = _comment[ 3 ];
		}

		if ( _hit_num >= 46 ) {
			_result.text = _comment[ 4 ];
		}
		string msg = "\n" + "breaking num:" + _hit_num.ToString( );
		_result.text += msg;
		_live_camera_text.text += msg;
	}
}
