using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScript : MonoBehaviour
{
    public Animator anim = null;  // Used to call Animator Controller triggers
    bool flipReady = false;

    void Flip()
    {
        anim.SetTrigger("Flip");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

}
