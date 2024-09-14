using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private float seconds_per_hour;
    [SerializeField] private int when_storm_starts = 6;
    private float seconds_left;
    private int cur_hour = 6;
    private TMP_Text text;

    private GameObject rain;
    void Start()
    {
        rain = GameObject.Find("Rain");
        text = GetComponent<TMP_Text>();
        seconds_left = seconds_per_hour;
    }

    private string half = "AM";
    void Update()
    {
        if(half == "AM")
            rain.SetActive(false);

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
                if(half == "PM")
                {
                    StartCoroutine(next_day());
                }
                cur_hour = 1;
            }
            if(cur_hour >= when_storm_starts && half == "PM" && cur_hour != 12)
            {
                foreach(GameObject g in GameObject.FindGameObjectsWithTag("Tile")) 
                {
                    g.GetComponent<TileAI>().flood();
                }
            }
            if (cur_hour == when_storm_starts-1 && half == "PM")
            {
                rain.SetActive(true);
            }
        }


        text.text = cur_hour.ToString() + ":00 " + half;
    }
    IEnumerator next_day()
    {
        yield return new WaitForSeconds(1);
    }
}
