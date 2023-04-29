using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    Rigidbody2D rb2d;
    HealthBars healthBars;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
      rb2d = GetComponentInParent<Rigidbody2D>();
      healthBars = GameObject.Find("UI").GetComponent<HealthBars>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // getting the damage from the hit box that enters it
    void OnTriggerEnter2D(Collider2D other){
      Debug.Log("triggered");
      if (other.gameObject.tag == "Hitbox1"){
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        rb2d.AddForce(new Vector3(hitbox.force.x, hitbox.force.y, 0));
        if (Input.GetKeyDown(KeyCode.M)){
          damage = hitbox.damage * .05f;
          healthBars.SetBar2OverTime(damage);
        }
        else {
          damage = hitbox.damage;
          healthBars.SetBar2OverTime(damage);
        }
        Debug.Log(damage);
      }

      if (other.gameObject.tag == "Hitbox2"){
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        rb2d.AddForce(new Vector3(hitbox.force.x, hitbox.force.y, 0));
        if (Input.GetKeyDown(KeyCode.C)){
          damage = hitbox.damage * .05f;
          healthBars.SetBar1OverTime(damage);
        }
        else {
          damage = hitbox.damage;
          healthBars.SetBar1OverTime(damage);
        }
        Debug.Log(damage);
      }
    }
}
