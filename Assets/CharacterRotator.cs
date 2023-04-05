using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string otherObjectTag = "Player";
    public float rotationAmount = 180f;

    private void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.CompareTag(otherObjectTag)){
          transform.parent.Rotate(new Vector3(0f, rotationAmount, 0f));
      }
    }
    private void OnTriggerExit2D(Collider2D other){
      if (other.gameObject.CompareTag(otherObjectTag)){
        transform.parent.Rotate(new Vector3(0f, -rotationAmount, 0f));
      }
    }

}
