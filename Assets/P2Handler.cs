using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Handler : MonoBehaviour
{
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
        rb2d = GetComponent<Rigidbody2D>();
        if (hitbox == null){
          hitbox = GetComponentInChildren<Hitbox>();
        }
    }

    // Update is called once per frame
    void Update()
    {
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
  
        if (Input.GetKeyDown(KeyCode.B)) {
          hitbox.ActivateHitbox(true);
        }
        if (Input.GetKeyUp(KeyCode.B)) {
          hitbox.ActivateHitbox(false);
        }
      }
    }

    IEnumerator Dash(Rigidbody2D rb, float dashDistance, float dashTime, float direction){
      rb.velocity = new Vector2(0, 0);
      Vector2 endPosition = rb.position + new Vector2(direction * dashDistance, 0f);
      Vector2 newVelocity = (endPosition - rb.position) / dashTime;
      float elapsedTime = 0f;
      // for making smoother dash
      // doesn't work well
      AnimationCurve curve = new AnimationCurve(
          new Keyframe(0, 0, 0, 2),
          new Keyframe(0.5f, 1, 2, 0),
          new Keyframe(1, 1, 0, 0));

      while (elapsedTime < dashTime) {
        float t = curve.Evaluate (elapsedTime / dashTime);
        rb.position = Vector2.Lerp(rb.position, endPosition, t);
        elapsedTime += Time.fixedDeltaTime;
        yield return null;
      }

      rb.position = endPosition;

      Vector2 postDashVelocity = rb.velocity;
      if (postDashVelocity.magnitude > newVelocity.magnitude){
        postDashVelocity = postDashVelocity.normalized * newVelocity.magnitude;
      }
      rb.velocity = newVelocity + postDashVelocity;
    }

    void FixedUpdate(){
      // rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed);
      // rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.fixedDeltaTime * speed * friction));
      if (rb2d.velocity.magnitude > maxSpeed){
        rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
      }
    }
}
