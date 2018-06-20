using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour {

	public Material[] materials;

	Transform device;


	bool wasInFront;
	bool inOtherWorld = false;

	bool hasCollided;

	// Use this for initialization
	void Start () {
		SetMaterials (false);
		device = Camera.main.gameObject.transform;
	}

	void SetMaterials(bool fullRender)
	{
		var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;

		foreach (var mat in materials) 
		{
			mat.SetInt ("_StencilTest", (int)stencilTest);
		}
	}
		
	bool GetIsInFront()
	{		
		Vector3 worldPos = device.position + device.forward * Camera.main.nearClipPlane;

		Vector3 pos = transform.InverseTransformPoint(worldPos);
		return pos.z >= 0 ? true : false;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("trigger enter");
		if (other.transform != device)
			return;
		hasCollided = true;
		wasInFront = GetIsInFront ();
	}

	void OnTriggerExit (Collider other) 
	{
		Debug.Log ("trigger exit");
		if (other.transform != device)
			return;
		hasCollided = false;
	}

	void WhileCameraColliding()
	{		
		if (!hasCollided)
			return;

		Debug.Log ("colliding");
		bool isInFront = GetIsInFront ();
		if ((isInFront && !wasInFront) || (!isInFront && wasInFront)) 
		{
			inOtherWorld = !inOtherWorld;
			SetMaterials (inOtherWorld);
			Debug.Log ("change");
		}
		wasInFront = isInFront;	
	}

	void OnDestory()
	{
		SetMaterials (true);
	}
	
	// Update is called once per frame
	void Update () {
		WhileCameraColliding();
	}
}


//
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Rendering;
//
//public class Portal : MonoBehaviour {
//
//	public Material[] materials;
//
//	public Transform device;
//
//	bool wasInFront;
//	bool inOtherWorld;
//
//	//bool hasCollided = false;
//
//	// Use this for initialization
//	void Start () {
//		SetMaterials (false);
//	}
//
//	void SetMaterials(bool fullRender)
//	{
//		var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
//
//		foreach (var mat in materials) 
//		{
//			mat.SetInt ("_StencilTest", (int)stencilTest);
//		}
//	}
//
//	bool GetIsInFront()
//	{
//
//		Vector3 worldPos = device.position + device.forward * Camera.main.nearClipPlane;
//
//		Vector3 pos = transform.InverseTransformPoint(worldPos);
//		return pos.z >= 0 ? true : false;
//	}
//
//	void OnTriggerEnter(Collider other)
//	{
//		if (other.transform != device)
//			return;
//		wasInFront = GetIsInFront ();
//	}
//
//	void OnTriggerStay (Collider other) 
//	{
//		if (other.transform != device)
//			return;
//		bool isInFront = GetIsInFront ();
//		if ((isInFront && !wasInFront) || (!isInFront && wasInFront)) 
//		{
//			inOtherWorld = !inOtherWorld;
//			SetMaterials (inOtherWorld);
//		}
//		wasInFront = isInFront;	
//	}
//
//	void OnDestory()
//	{
//		SetMaterials (true);
//	}
//
//	// Update is called once per frame
//	void Update () {
//		//WhileCameraColliding();
//	}
//}
