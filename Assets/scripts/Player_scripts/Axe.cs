using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(play_anim());
        }
    }

    IEnumerator play_anim()
    {
        anim.Play("Axe_swing");
        yield return new WaitForSeconds(1);
        anim.Play("Idle");
    }
}
