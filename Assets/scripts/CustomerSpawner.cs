using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] customers = new GameObject[5];
    public float[] spawnTimes = new float[5];
    private float temp = 0;

    public float countdown = 0;
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < spawnTimes.Length; i++)
        {
            
            spawnTimes[i] = Random.Range(120 * (i / (float)customers.Length), 150 * ((i) / (float)customers.Length));
            if (i == 0)
            {
                spawnTimes[i] = 5;
            }
        }
        for(int i = 0; i < spawnTimes.Length - 1;i++)
        {
            if (spawnTimes[i] > spawnTimes[i+1])
            {
                temp = spawnTimes[i];
                spawnTimes[i] = spawnTimes[i+1];
                spawnTimes[i + 1] = temp;
            }
            if (spawnTimes[i] + 5 > spawnTimes[i+1]) //if there isn't a 5 second cooldown, add one.
            {
                spawnTimes[i + 1] += 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        for(int i = 0; i < spawnTimes.Length; i++)
        {
            if (spawnTimes[i] < countdown)
            {
                customers[i].gameObject.SetActive(true);
            }
        }
    }
    
}
