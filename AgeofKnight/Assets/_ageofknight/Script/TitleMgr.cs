using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleMgr : MonoBehaviour {

	private void Start(){
		Invoke( "SceneChange", 1 );
	}
	void SceneChange () {
			SceneManager.LoadScene(1);
	}

}
