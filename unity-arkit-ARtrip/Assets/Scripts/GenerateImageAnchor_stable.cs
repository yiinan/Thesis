﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class GenerateImageAnchor_stable : MonoBehaviour {


	[SerializeField]
	private ARReferenceImage referenceImage;

	[SerializeField]
	private GameObject prefabToGenerate;

	private GameObject imageAnchorGO;

	// Use this for initialization
	void Start () {
		UnityARSessionNativeInterface.ARImageAnchorAddedEvent += AddImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += UpadteImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += RemoveImageAnchor;

	}

	void AddImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.Log ("image anchor added");
		if (arImageAnchor.referenceImageName == referenceImage.imageName) {
			Vector3 position = UnityARMatrixOps.GetPosition (arImageAnchor.transform);
			Quaternion rotation = UnityARMatrixOps.GetRotation (arImageAnchor.transform);

			//GameObject shadowPlane = (GameObject)Instantiate(Resources.Load("shadowPlanePrefab"), position, rotation);

			imageAnchorGO = Instantiate<GameObject> (prefabToGenerate, position, rotation);
			imageAnchorGO.AddComponent<Lean.Touch.LeanScale> ();
			//imageAnchorGO.AddComponent<Lean.Touch.LeanTranslate> ();
			imageAnchorGO.AddComponent<Lean.Touch.LeanRotate> ();
		}
	}

	void UpadteImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.Log ("image anchor updated");
		if (arImageAnchor.referenceImageName == referenceImage.imageName) {
			imageAnchorGO.transform.position = UnityARMatrixOps.GetPosition (arImageAnchor.transform);
			imageAnchorGO.transform.rotation = UnityARMatrixOps.GetRotation (arImageAnchor.transform);
		}

	}

	void RemoveImageAnchor(ARImageAnchor arImageAnchor)
	{
		Debug.Log ("image anchor removed");
		if (imageAnchorGO) {
			GameObject.Destroy (imageAnchorGO);
		}

	}

	void OnDestroy()
	{
		UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= AddImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent -= UpadteImageAnchor;
		UnityARSessionNativeInterface.ARImageAnchorRemovedEvent -= RemoveImageAnchor;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
