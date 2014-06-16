using UnityEngine;
using System.Collections;

public class CameraMove2D : MonoBehaviour {
	public GameObject  unitycan; //Unitychanを選択しておくこと。
	private Vector3 foge;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foge=unitycan.transform.position;
		foge.z=-235;
		foge.y+=4;
		transform.position=foge;
	}
}
