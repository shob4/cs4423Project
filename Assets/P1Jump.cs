using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Jump : MonoBehaviour
{

    [Header("Jump Parameters")]
    public float jumpForce; 
    float jumpTime;
    float fullTime = 0.02f;
    public int jumpSquat = 3;
    public int action;

    public GroundCheck groundCheck;
    bool jumping = false;
    // may not do anything

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // first jump
        bool grounded = groundCheck.isGrounded;
        if (Input.GetKeyDown(KeyCode.W) & grounded){
            jumping = true;
            grounded = false;
            action = 1;
        } 
        if (jumping){
            jumpTime += Time.deltaTime;
            WaitFor.Frames(jumpSquat);
        }
        if (jumpTime < fullTime & jumping){
            jumping = false;
            Debug.Log(jumpTime);
            jumpTime = 0;
            rb2d.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
            // TODO figure out if else for air dashing. separate file?
            // maybe use switch case for checking angle of jump
            if (Input.GetKeyDown(KeyCode.Z) & action > 0){
                Debug.Log("air dash");
                rb2d.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * 10, Input.GetAxisRaw("Vertical") * 10));
                action -= 1;
            }
        }
        else if ((Input.GetKeyUp(KeyCode.I) | jumpTime > fullTime) & jumping){
            jumping = false;
            Debug.Log(jumpTime);
            jumpTime = 0;
            rb2d.AddForce(new Vector2(0, 2f) * jumpForce, ForceMode2D.Impulse);
            if (Input.GetKeyDown(KeyCode.Z) & action > 0){
                Debug.Log("air dash");
                rb2d.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * 10, Input.GetAxisRaw("Vertical") * 10));
                action -= 1;
            }
        }
    }
}
