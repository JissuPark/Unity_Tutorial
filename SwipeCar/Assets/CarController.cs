using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	float speed = 0; 
	Vector2 start, end; 
	void Start () {
		
	}
	
	void Update () {
		
		if(Input.GetMouseButtonDown(0)){
			this.start = Input.mousePosition;
		}		
		else if(Input.GetMouseButtonUp(0)){
			this.end =Input.mousePosition;
			float swipelength = (this.end.x - this.start.x);
			speed = swipelength/1000.0f;
			GetComponent<AudioSource>().Play();	
		}
		transform.Translate(this.speed, 0, 0);
		this.speed *= 0.98f;
	}
}
