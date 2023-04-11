using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

  public bool isGrounded;
  public Transform groundCheck;
  public float groundCheckRadius = 0.01f;
  public LayerMask whatIsGround;

  private void FixedUpdate() {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
  }
}
