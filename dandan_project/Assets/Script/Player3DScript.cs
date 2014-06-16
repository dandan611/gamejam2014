using UnityEngine;
using System.Collections;

public class Player3DScript : MonoBehaviour {

    private Animator animator;
    private Camera camera3d;
    public bool isJamping;
    protected float jump_speed = 6.0f;
    protected const float cameraMinZ = -200.0f;
    protected const float cameraMaxZ = 200.0f;

    UnityChan2DController aaa;

	void Start () {
        animator = GetComponent<Animator>();
        camera3d = GameObject.Find("3Dcamera").GetComponent<Camera>();
        isJamping = false;
        aaa = GameObject.Find("2DUnityChan").GetComponent<UnityChan2DController>();
	}
	
	void Update () {
        if (Time.timeScale == 1)
        {
                if ((!isJamping) && Input.GetKeyDown("space"))
                {
                    if (camera3d.transform.position.z > cameraMinZ) // Z軸移動最小領域判定
                    {
                        isJamping = true;
                        this.rigidbody.velocity = Vector3.up * this.jump_speed;
                        transform.position += transform.forward * 0.2f;
                        camera3d.transform.position += transform.forward * 0.2f;
                        animator.SetBool("running_jump", true);
                        animator.SetBool("is_running", false);
                    }
                }
                else
                {
                    if (isJamping)
                    {
                        transform.position += transform.forward * 0.2f;
                        camera3d.transform.position += transform.forward * 0.2f;
                        animator.SetBool("running_jump", true);
                    }
                    else
                    {
                        if (Input.GetKey("right"))
                        {
                            if (camera3d.transform.position.z < cameraMaxZ) // Z軸移動最大領域判定
                            {
                                transform.position += transform.forward * 0.2f;
                                camera3d.transform.position += transform.forward * 0.2f;
                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                animator.SetBool("is_running", true);
                            }
                        }
                        else if (Input.GetKey("left"))
                        {
                            if (camera3d.transform.position.z > cameraMinZ) // Z軸移動最小領域判定
                            {
                            transform.position += transform.forward * 0.2f;
                            camera3d.transform.position += transform.forward * 0.2f;
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            animator.SetBool("is_running", true);
                            }
                        }
                        else
                        {
                            animator.SetBool("is_running", false);
                        }
                    }
            }
        }	
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "3DRoad")
        {
            this.isJamping = false;
            animator.SetBool("running_jump", false);
            animator.SetBool("is_running", false);
        }

        if(collision.gameObject.tag == "DamageObject")
        {
            Debug.Log(aaa.unitychanHP);
            aaa.unitychanHP--;
            GameObject heart = GameObject.Find("heart2");
            if (heart != null)
            {
                Destroy(heart);
            }
            else
            {
                Destroy(GameObject.Find("heart1"));
            }
            if ((aaa.unitychanHP <= 0))
            {
                Time.timeScale = 0;
                GameObject.Find("GameOverText").GetComponent<GUIText>().enabled = true;
            }
        }

        if (collision.gameObject.name == "3Dcurrycoro") //ゲームクリア
        {
            Time.timeScale = 0;
            Application.LoadLevel("EndScene");
        }
    }

}
