using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash // TODO maybe put this in character handler? having them separate would be nice
{
		public IEnumerator Dash(Rigidbody2D rb, float dashDistance, float dashTime){
						Vector2 endPosition = rb.position + new Vector2(transform.localScale.x + dashDistance, transform.localScale.y);
						Vector2 newVelocity = (endPosition - rb.position) / dashTime;
						float elapsedTime = 0f;
						while (elapsedTime < dashTime) {
										rb.position = Vector2.Lerp(rb.position, endPosition, (elapsedTime / dashTime));
										elapsedTime += Time.deltaTime;
										yield return null;
						}

						rb.position = endPosition;

						Vector2 postDashVelocity = rb.velocity;
						if (postDashVelocity.magnitude > newVelocity.magnitude){
										postDashVelocity = postDashVelocity.normalized * newVelocity.magnitude;
						}
						rb.velocity = newVelocity + postDashVelocity;
		}
}
