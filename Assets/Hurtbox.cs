using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
      rb2d = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // getting the damage from the hit box that enters it
    void OnTriggerEnter2D(Collider2D other){
      Debug.Log("triggered");
      if (other.gameObject.tag == "Hitbox"){
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        rb2d.AddForce(new Vector2(hitbox.force.x, hitbox.force.y));
        double damage;
        if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.M)){
          damage = hitbox.damage * .05;
        }
        else {
          damage = hitbox.damage;
        }
        Debug.Log(damage);
      }
    }
}
