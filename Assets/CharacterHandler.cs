using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;
    public float maxSpeed = 15f;
    public float forceMultiplier = 10f;
    public float friction = .95f;

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
		float dashTime = .15f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
				if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
				{
				    if (pressedFirstTime)
				    {
				        bool isDoublePress = Time.time - lastPressedTime <= delayBetweenPresses;
								if (isDoublePress)
								    {
												pressedFirstTime = false;
												float direction = Input.GetAxis("Horizontal");
												// TODO fixed distance and speed dash
												Dash(rb2d, dashDistance, dashTime, direction);
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

				rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed * friction);
    }

		IEnumerator Dash(Rigidbody2D rb, float dashDistance, float dashTime, float direction){
						Vector2 endPosition = rb.position + new Vector2(direction * dashDistance, 0f);
						Vector2 newVelocity = (endPosition - rb.position) / dashTime;
						float elapsedTime = 0f;
						while (elapsedTime < dashTime) {
										rb.position = Vector2.Lerp(rb.position, endPosition, (elapsedTime / dashTime));
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
