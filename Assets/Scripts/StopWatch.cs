using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    private float timer;
    private float minutes;
    private float seconds;
    private float milliseconds;

    [SerializeField]
    private Text stopWatchText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StopWatchCalc();
    }

    void StopWatchCalc()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        milliseconds = timer * 1000;
        seconds = (int)(timer % 60);
        minutes = (int)((timer / 60) % 60);

        stopWatchText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}.{milliseconds.ToString("0000")}";
    }
}
