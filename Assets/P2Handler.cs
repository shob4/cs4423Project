using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Handler : MonoBehaviour
{
    public GroundCheck groundCheck;
    public bool isActive;
    
    [Header("Movement")]
    public float speed = 10f;
    public float maxSpeed = 15f;
    public float forceMultiplier = 10f;
    public float friction = .95f;
    private bool isRunning = false;

    [Header("Outside Object")]
    Rigidbody2D rb2d;

    [Header("Text Elements")]
    int trueHealth;
    int falseHealth;

    [Header("Dash")]
    float delayBetweenPresses = 0.25f;
    bool pressedFirstTime = false;
    float lastPressedTime;
    float dashDistance = 10f;
    float dashTime = .5f;

    Hitbox hitbox;
    // Start is called before the first frame update
    void Start()
    {
        groundCheck = GetComponent<GroundCheck>();
        rb2d = GetComponent<Rigidbody2D>();
        if (hitbox == null){
          hitbox = GetComponentInChildren<Hitbox>();
        }
    }

    // Update is called once per frame
    void Update()
    {
      isActive = groundCheck.isGrounded;
      if (isActive){
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
        {
          if (pressedFirstTime)
          {
            bool isDoublePress = Time.time - lastPressedTime <= delayBetweenPresses;
            if (isDoublePress)
            {
              pressedFirstTime = false;
              float direction = Input.GetAxis("Horizontal2");
              StartCoroutine(Dash(rb2d, dashDistance, dashTime, direction));
            }
          }
          else {
            pressedFirstTime = true;
          }
          lastPressedTime = Time.time;
        }
        if (pressedFirstTime && Time.time - lastPressedTime > delayBetweenPresses)
        {
          pressedFirstTime = false;
        }
  
        if (Input.GetKeyDown(KeyCode.B) || isRunning == true){
          rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal2"), 0) * speed * friction);
        }
        else{
          rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal2"), 0) * (speed / 3) * friction);
        }
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.L)){
          isRunning = false;
        }
  
        if (Input.GetKeyDown(KeyCode.N)) {
          hitbox.ActivateHitbox(true);
        }
        if (Input.GetKeyUp(KeyCode.N)) {
          hitbox.ActivateHitbox(false);
        }
      }
    }

    IEnumerator Dash(Rigidbody2D rb, float dashDistance, float dashTime, float direction){
      float elapsedTime = 0f;

      speed = speed * (dashDistance / dashTime);
      while (elapsedTime < dashTime) {
        elapsedTime += Time.fixedDeltaTime;
        yield return null;
      }
      speed = speed / (dashDistance / dashTime);
    }

    void FixedUpdate(){
      // rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed);
      // rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.fixedDeltaTime * speed * friction));
      if (rb2d.velocity.magnitude > maxSpeed){
        rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
      }
    }
}
