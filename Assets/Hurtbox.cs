using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // getting the damage from the hit box that enters it
    void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag == "hitbox"){
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        int damage = hitbox.damage;
        Debug.Log(damage);
      }
    }
}
