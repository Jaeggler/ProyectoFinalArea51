using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour {

	public string sceneName;
	public float delay;

	// Use this for initialization
	void Start () {
	
	}
	
	public void ChangeScene(string scene){
		SceneManager.LoadScene (scene);

	}

	public void ChangeScene(){
		SceneManager.LoadScene (sceneName);
	}

}
