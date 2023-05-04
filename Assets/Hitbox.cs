using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // should be determined when instantiated
    public float damage = 25f;
    Collider2D c2d;
    public Vector2 force = new Vector2(10000f, 1000f);
    // Start is called before the first frame update
    void Start()
    {
      c2d = GetComponent<Collider2D>();
    }

    public void ActivateHitbox(bool activate){
      c2d.enabled = activate;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
