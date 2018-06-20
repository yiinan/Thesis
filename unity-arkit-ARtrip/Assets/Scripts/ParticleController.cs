using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

	public ParticleSystem snow;
	public ParticleSystem rain;
	public ParticleSystem rainsheet;
	public ParticleSystem rainsheet2;
	public ParticleSystem rainbow;


	// Use this for initialization
	void Start () {
		snow.Stop ();
		rain.Stop ();
		rainsheet.Stop ();
		rainsheet2.Stop ();
		rainbow.Stop ();
	}

	public void SnowOn(){
		rain.Stop ();
		rainsheet.Stop ();
		rainsheet2.Stop ();
		rainbow.Stop ();
		Vector3 cam = Camera.main.gameObject.transform.position;
		snow.transform.position = cam;
		snow.Play ();
	}

	public void RainOn(){
		snow.Stop ();
		rainbow.Stop ();
		Vector3 cam = Camera.main.gameObject.transform.position;
		rainsheet.transform.position = cam;
		rainsheet2.transform.position = cam;
		rain.transform.position = cam;
		rain.Play ();
		rainsheet.Play ();
		rainsheet2.Play ();
	}

	public void RainbowOn(){
		snow.Stop ();
		rain.Stop ();
		rainsheet.Stop ();
		rainsheet2.Stop ();
		Vector3 cam = Camera.main.gameObject.transform.position;
		rainbow.transform.position = cam;
		Quaternion rot = new Quaternion(0, 0, 0, 1);
		rot.y = Camera.main.gameObject.transform.rotation.y;
		rot.w = Camera.main.gameObject.transform.rotation.w;
		rainbow.transform.rotation = rot;
//		cam.z += 280;
//		cam.y += 28;
		rainbow.transform.position = Camera.main.transform.forward * 280;
		rainbow.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
