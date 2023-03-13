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
												// TODO fixed distance and speed dash
												StartCoroutine(WaitFor.Frames(10));
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

    void FixedUpdate(){
        // rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed);
        // rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.fixedDeltaTime * speed * friction));
        if (rb2d.velocity.magnitude > maxSpeed){
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }
}
