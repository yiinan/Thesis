using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

	public Canvas canvasPanel;


	// Use this for initialization
	void Start () {
		canvasPanel.enabled = false;
	}

	public void ShowPanel(){
		canvasPanel.enabled = true;
	}

	public void ClosePanel(){
		canvasPanel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
