using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	public void ChangeToScene1(){
		SceneManager.LoadScene ("ImageAnchorMap", LoadSceneMode.Single);
	}

	public void ChangeToMainScene(){
		SceneManager.LoadScene ("main", LoadSceneMode.Single);
	}

	public void ChangeToParkScene(){
		SceneManager.LoadScene ("park", LoadSceneMode.Single);
	}

	public void ChangeToSnowScene(){		
		SceneManager.LoadScene ("snow", LoadSceneMode.Single);
	}

	public void ChangeToScene4(){
		SceneManager.LoadScene ("UnityARImageAnchor", LoadSceneMode.Single);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
