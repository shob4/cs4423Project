using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
  public GameObject UI;
  public Transform bar1Transform;
  public Transform grey1Transform;
  public Transform bar2Transform;
  public Transform grey2Transform;
  float timer = 2f;

  [Range(0f, 1f)]
  public float progress1 = 1f;
  [Range(0f, 1f)]
  public float progress2 = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bar1Transform = GameObject.Find("TopHealth1").transform;
        grey1Transform = GameObject.Find("GreyHealth1").transform;
        bar2Transform = GameObject.Find("TopHealth2").transform;
        grey2Transform = GameObject.Find("GreyHealth2").transform;
        SetBar1();
        SetBar2();
    }
    void SetBar2(){
      bar2Transform.localScale = new Vector3(progress2,1,1);
    }

    public void SetBar2Progress(float sub){
      bar2Transform.localScale = new Vector3(progress2 - sub, 1, 1);
      SetBar2OverTime(sub, progress2);
      progress2 = progress2 - sub;
    }

    public void SetBar2OverTime(float progressToBeMade, float currentProgress){
      float t = Time.deltaTime;
      float amountToMoveBy = progressToBeMade / timer;
      while (t < timer) {
        grey2Transform.localScale = new Vector3(currentProgress - amountToMoveBy, 1, 1);
      }
    }
    void SetBar1(){
      bar1Transform.localScale = new Vector3(progress1,1,1);
    }

    public void SetBar1Progress(float sub){
      bar1Transform.localScale = new Vector3(progress1 - sub, 1, 1);
      SetBar1OverTime(sub, progress1);
      progress1 = progress1 - sub;
    }

    public void SetBar1OverTime(float progressToBeMade, float currentProgress){
      float t = Time.deltaTime;
      float amountToMoveBy = progressToBeMade / timer;
      while (t < timer) {
        grey1Transform.localScale = new Vector3(currentProgress - amountToMoveBy, 1, 1);
      }
    }
    // Update is called once per frame
    void Update()
    {
    }

}
