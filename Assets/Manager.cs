using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public Text State;
    public Text Goal;
    public Text choText;

    float t;

    public float sum;
    public float randomFloat;

    public int cho;

    public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        t = Mathf.Floor(Input.acceleration.x*100f*10f)/10f;
        State.text=sum.ToString();
        Goal.text="목표 : "+randomFloat.ToString();
        if(randomFloat==sum){
            GameEnd();
        }
    }
    IEnumerator se()
    {
        while(true)
        {
            sum+=t;
            sum = Mathf.Floor(sum*10f)/10f;
            cho+=1;
            yield return new WaitForSecondsRealtime( 1.0f );
        }
    }
    public void GameStart()
    {
        cho=0;
        randomFloat = Random.Range(-100.0f,100.0f);
        randomFloat = Mathf.Floor(randomFloat*10f)/10f;
        StartCoroutine("se");
        sum=0.0f;
    }
    void GameEnd()
    {
        choText.text=cho.ToString();
        StopCoroutine("se");
        EndScreen.SetActive(true);
    }
    public void Bye()
    {
        Application.Quit();
    }

}
