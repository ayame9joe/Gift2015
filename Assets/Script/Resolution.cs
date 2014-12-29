using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(480, 800, true, 60);
		//mainCamera = Camera.mainCamera;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
