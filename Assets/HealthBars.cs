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
  public float timer = 2f;
  [Range(0f, 1f)]
  public float progress1 = 0f;
  public float progress2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bar1Transform = UI.transform.Find("TopHealth1");
        grey2Transform = UI.transform.Find("GreyHealth1");
        bar2Transform = UI.transform.Find("TopHealth2");
        grey2Transform = UI.transform.Find("GreyHealth2");
        SetBar1();
        SetBar2();
    }
    void SetBar2(){
      bar2Transform.localScale = new Vector3(progress2,1,1);
    }

    public void SetBar2Progress(float progress){
      bar2Transform.localScale = new Vector3(progress2, 1, 1);
    }

    public void SetBar2OverTime(float progressToBeMade){
      float t = Time.deltaTime;
      float amountToMoveBy = progressToBeMade / timer;
      while (t < timer) {
        SetBar1Progress(progress2 + amountToMoveBy);
      }
    }
    void SetBar1(){
      bar1Transform.localScale = new Vector3(progress1,1,1);
    }

    public void SetBar1Progress(float progress){
      bar1Transform.localScale = new Vector3(progress1, 1, 1);
    }

    public void SetBar1OverTime(float progressToBeMade){
      float t = Time.deltaTime;
      float amountToMoveBy = progressToBeMade / timer;
      while (t < timer) {
        SetBar1Progress(progress1 + amountToMoveBy);
      }
    }
    // Update is called once per frame
    void Update()
    {
      SetBar1();
      SetBar2();
    }

}
