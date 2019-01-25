using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour {
	float rotspeed = 0;
	void Start () {
		
	}
	
	void Update () {
		if(Input.GetMouseButton(0)){
			this.rotspeed = 100;
		}		
		transform.Rotate(0,0,this.rotspeed);
		this.rotspeed *= 0.96f;
	}
}
