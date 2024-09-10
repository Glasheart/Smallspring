using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D axe_collider;

    void Start()
    {
        anim = GetComponent<Animator>();
        axe_collider = GetComponent<BoxCollider2D>();
        axe_collider.enabled = false;
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
        axe_collider.enabled = true;
        anim.Play("Axe_swing");
        yield return new WaitForSeconds(1);
        anim.Play("Idle");
        axe_collider.enabled = false;
    }
}
