using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

public class Movement : MonoBehaviour
{
    float h, v;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        switch (h)
        {
            case 0:
                Debug.Log("a");
                break;
            case 1:
                Debug.Log("b");
                animator.SetBool("flip", false);
                break;
            case -1:
                Debug.Log("c");
                animator.SetBool("flip", true);
                break;
        }

        Debug.Log(h + "  " + v);


    }
}
