using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy_move1 : MonoBehaviour {

	private Rigidbody2D m_rigidbody2D;
	public float moveSpeed = -2f;		// The speed the enemy moves at.

	// Use this for initialization
	void Start () {
		Debug.Log ("start");
	}
	
	// Update is called once per frame
	void Update () {
	}
	// OnWillRenderObject
	void OnWillRenderObject()
	{
		Debug.Log("Camera.current.name");
		rigidbody2D.velocity = - new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	
	}
}