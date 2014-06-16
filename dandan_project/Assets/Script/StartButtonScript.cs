using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
    void OnGUI () 
	{
    	Rect rect = new Rect(10, 250, 180, 80);

    	bool isClicked = GUI.Button(rect, "Start Game");
    	
    	if(isClicked)
    	{
    		Application.LoadLevel("GameScene");
    	}
	}
}
