using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] customers = new GameObject[5];
    public float[] spawnTimes = new float[5];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawnTimes.Length; i++)
        {
            spawnTimes[i] = Random.Range(120 * (i / (float)customers.Length), 150 * ((i+1) / (float)customers.Length));
        }
        for(int i = 0; i < spawnTimes.Length - 1;i++)
        {
            if (spawnTimes[i] + 5 > spawnTimes[i+1] && spawnTimes[i] > spawnTimes[i+1])
            {
                spawnTimes[i + 1] += 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
