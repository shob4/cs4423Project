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
      if (other.gameObject.tag == "Hibox1"){
        Debug.Log("check1");
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        rb2d.AddForce(new Vector3(hitbox.force.x, hitbox.force.y, 0));
        Debug.Log("check2");
        if (Input.GetKeyDown(KeyCode.M)){
          Debug.Log("check3");
          damage = hitbox.damage * .05f;
          healthBars.SetBar2Progress(damage / 2000);
          Debug.Log("check4");
        }
        else {
          Debug.Log("check3");
          damage = hitbox.damage;
          healthBars.SetBar2Progress(damage / 1000);
          Debug.Log("check4");
        }
        Debug.Log(damage);
      }

      if (other.gameObject.tag == "Hitbox2"){
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        rb2d.AddForce(new Vector3(hitbox.force.x, hitbox.force.y, 0));
        if (Input.GetKeyDown(KeyCode.C)){
          damage = hitbox.damage * .05f;
          healthBars.SetBar1Progress(damage / 2000);
        }
        else {
          damage = hitbox.damage;
          healthBars.SetBar1Progress(damage / 1000);
        }
        Debug.Log(damage);
      }
    }
}
