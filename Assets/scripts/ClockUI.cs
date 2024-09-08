using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private float seconds_per_hour;
    private float seconds_left;
    private int cur_hour = 6;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        seconds_left = seconds_per_hour;
    }

    private string half = "AM";
    void Update()
    {
        seconds_left -= Time.deltaTime;

        if(seconds_left <= 0)
        {
            seconds_left = seconds_per_hour;
            cur_hour++;
            if (cur_hour > 11)
            {
                half = "PM";
            }
            if (cur_hour > 12)
            {
                cur_hour = 1;
            }
        }


        text.text = cur_hour.ToString() + ":00 " + half;
    }
}
