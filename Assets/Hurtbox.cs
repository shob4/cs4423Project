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
    void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag == "hitbox"){
        int damage = other.gameObject.GetComponent<damage>();
        Debug.Log(damage);
      }
    }
}
