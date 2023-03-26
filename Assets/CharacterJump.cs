using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [Header("Jump Parameters")]
    public float jumpForce; 
    float jumpTime;
    float fullTime = 0.02f;

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
        bool grounded = groundCheck.isGrounded;
        if (Input.GetKeyDown(KeyCode.Space) & grounded){
            jumping = true;
            grounded = false;
        } 
        if (jumping){
            jumpTime += Time.deltaTime;
        }
				// TODO WaitFor and see if still holding button
        if ((Input.GetKeyUp(KeyCode.Space) | jumpTime < fullTime) & jumping){
            jumping = false;
            Debug.Log(jumpTime);
            jumpTime = 0;
            rb2d.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
        }
        else if ((Input.GetKeyUp(KeyCode.Space) | jumpTime > fullTime) & jumping){
            jumping = false;
            Debug.Log(jumpTime);
            jumpTime = 0;
            rb2d.AddForce(new Vector2(0, 2f) * jumpForce, ForceMode2D.Impulse);
        }
    }

}
