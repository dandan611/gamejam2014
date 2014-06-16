using UnityEngine;
using System.Collections;

public class CameraManagerScript : MonoBehaviour {

    public Camera aaa;
    public Camera bbb;
    public AudioListener audioListenerFor3d;
    public AudioListener audioListenerFor2d;
    private GameObject unitychan2D;
    private GameObject unitychan3D;

    UnityChan2DController aa;

	// Use this for initialization
	void Start () {
	    aaa = GameObject.Find("3Dcamera").GetComponent<Camera>();
        bbb = GameObject.Find("2Dcamera").GetComponent<Camera>();
        audioListenerFor3d = GameObject.Find("3Dcamera").GetComponent<AudioListener>();
        audioListenerFor2d = GameObject.Find("2Dcamera").GetComponent<AudioListener>();

        audioListenerFor3d.enabled = true;
        audioListenerFor2d.enabled = false;

        bbb.enabled = false; //最初は、2Dカメラを使用しない。
	}
	
	// Update is called once per frame
	void Update ()
    {
        // xキー
        if (Input.GetKeyDown("x"))
        {
            if (aaa.enabled)
            {
                aaa.enabled = false;
                audioListenerFor3d.enabled = false;
                bbb.enabled = true;
                audioListenerFor2d.enabled = true;
            }
            else
            {
                aaa.enabled = true;
                audioListenerFor3d.enabled = true;

                bbb.enabled = false;
                audioListenerFor2d.enabled = false;
            }
        } 	
	}
}
