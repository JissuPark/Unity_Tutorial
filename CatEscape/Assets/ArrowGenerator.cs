using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour {

	public GameObject arrowPrefab;
	float span = 1.0f;
	float delta = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;//delta time is 1/60 seconds.
		if(this.delta > this.span)//means 1 second.
		{
			this.delta = 0;
			GameObject go = Instantiate(arrowPrefab) as GameObject;//generate arrow
			int px = Random.Range(-6,7);//in random position
			go.transform.position = new Vector3(px, 7, 0);
		}	
	}
}
