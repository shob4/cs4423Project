using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

				public bool isGrounded;
				public Transform groundCheck;
        public float groundCheckRadius = 2f;
        public LayerMask whatIsGround;

				private void FixedUpdate() {
								isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
				}
}
