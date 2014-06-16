using UnityEngine;
using System.Collections;

public class Zombi3DScript : MonoBehaviour {

    private Animator animator;
    public float moveSpeed = 0.01f;		// The speed the enemy moves at.
    public bool behavioreActiveMode = false;

	void Start () {
        animator = GetComponent<Animator>();
        behavioreActiveMode = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (behavioreActiveMode)
        {
            this.transform.position += transform.forward * moveSpeed;
            animator.SetBool("is_running", true);
        }
        else
        {
            animator.SetBool("is_running", false);
        }	
	}

    void OnWillRenderObject()
    {
        Debug.Log("Camera.current.name");

    }
}
