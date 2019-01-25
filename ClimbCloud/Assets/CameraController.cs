using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	GameObject camera;
	// Use this for initialization
	void Start () {
		this.camera = GameObject.Find("cat");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 camerapose = this.camera.transform.position;
		transform.position = new Vector3(camerapose.x, camerapose.y, transform.position.z);
	}
}
