using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBars : MonoBehaviour
{
  public GameObject UI;
  public Transform bar1Transform;
  public Transform grey1Transform;
  public Transform bar2Transform;
  public Transform grey2Transform;
  public Text text1;
  public Text text2;
  float timer = 200f;

  [Range(0f, 1f)]
  float progress1 = 1f;
  [Range(0f, 1f)]
  float progress2 = 1f;

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
      float t = 0f;
      float percent;
      Vector3 startPosition = new Vector3(currentProgress, 1, 1);
      Vector3 endPosition = new Vector3(currentProgress - progressToBeMade, 1, 1);
      while (t < timer) {
        percent = t / timer;
        grey2Transform.localScale = Vector3.Lerp(startPosition, endPosition, percent);
        t += Time.deltaTime;
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
      float percent;
      float t = 0f;
      Vector3 startPosition = new Vector3(currentProgress, 1, 1);
      Vector3 endPosition = new Vector3(currentProgress - progressToBeMade, 1, 1);
      while (t < timer) {
        percent = t / timer;
        grey1Transform.localScale = Vector3.Lerp(startPosition, endPosition, percent);
        t += Time.deltaTime;
      }
    }
    // Update is called once per frame
    void Update()
    {
      SetBar1();
      SetBar2();
      if (progress1 <= 0){ // TODO turn on text, move to start menu
        text1.enabled = true;
        SceneManager.LoadScene("MainMenu");
      }
      if (progress2 <= 0){
        text2.enabled = true;
        SceneManager.LoadScene("MainMenu");
      }
    }

}
