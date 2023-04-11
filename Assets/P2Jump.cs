using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Jump : MonoBehaviour
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

    bool firstInput;
    public P2Handler p2handler;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        p2handler = GetComponent<P2Handler>();
    }

    // Update is called once per frame
    void Update()
    {
        // first jump
        bool grounded = groundCheck.isGrounded;
        if (Input.GetKeyDown(KeyCode.I) & grounded){
            jumping = true;
            grounded = false;
            action = 1;
            p2handler.isActive = false;
        } 
        if (jumping){
            jumpTime += Time.deltaTime;
        }
        WaitFor.Frames(jumpSquat);
        if (jumpTime < fullTime & jumping){
            jumping = false;
            Debug.Log(jumpTime);
            jumpTime = 0;
            rb2d.AddForce(new Vector2(0, 1) * (jumpForce * 2), ForceMode2D.Impulse);
            // TODO figure out if else for air dashes
        }
        else if ((Input.GetKeyUp(KeyCode.I) | jumpTime > fullTime) & jumping){
            jumping = false;
            Debug.Log(jumpTime);
            jumpTime = 0;
            rb2d.AddForce(new Vector2(0, 2f) * jumpForce, ForceMode2D.Impulse);
            // only after jumping
//            if (action > 0 && Input.GetKeyDown(KeyCode.L)){
//              if (firstInput) {
                //TODO dash
//              }
//            }
        }
        WaitFor.Frames(jumpSquat);
        if (grounded){
          p2handler.isActive = true;
        }
    }
}
