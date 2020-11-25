using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text;
    public int TurnTime = 30;
    private int totalTime;

    public int TotalTime { get => totalTime; set => totalTime = value; }

    void Start()
    {

        ResetTime();
        StartCoroutine(countDown());

    }

    public void ResetTime()
    {
        totalTime = TurnTime;
    }

    IEnumerator countDown()
    {
        while (TotalTime >= 0)
        {
            string tmp;
            if (TotalTime <= 10)
            {
                tmp = "<color=red><size=100>" + TotalTime.ToString() + "</size></color>";
            }
            else tmp = "<color=blue><size=80>" + TotalTime.ToString() + "</size></color>";
            text.GetComponent<Text>().text = tmp;
            yield return new WaitForSeconds(1);
            TotalTime--;

        }
    }
}
