using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class LoadPark : MonoBehaviour {

	bool loaded = false;
	Quaternion rot;

	// Use this for initialization
	void Start () {
		//Debug.Log ("initial rot: " + Camera.main.gameObject.transform.rotation.y);
	}

	public void LoadPortal(){
		if (!loaded) {
			Vector3 cam = Camera.main.gameObject.transform.position;
			//cam.z += 5;
			rot = new Quaternion(0, 0, 0, 1);
			rot.y = Camera.main.gameObject.transform.rotation.y;
			rot.w = Camera.main.gameObject.transform.rotation.w;
			//Debug.Log ("rotation:" + rot.y);
			//Vector3 pos = cam + cam.forward * 5;new Quaternion(0, 0, 0, 1)

			GameObject park = (GameObject)Instantiate(Resources.Load("WorldContainer"), cam, rot);
			//park.transform.position = Camera.main.transform.forward * 4;
			loaded = true;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
