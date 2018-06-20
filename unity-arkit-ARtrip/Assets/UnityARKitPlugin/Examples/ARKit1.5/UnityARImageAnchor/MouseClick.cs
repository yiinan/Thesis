using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

	public GameObject info;
	bool infoShow = false;

	// Use this for initialization
	void Start () {
		info.SetActive (false);
	}

	void OnMouseDown ()
	{
		infoShow = !infoShow;
		if (infoShow) {
			info.SetActive (true);
		} else {
			info.SetActive (false);
		}
		//Debug.Log ("clicked");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
