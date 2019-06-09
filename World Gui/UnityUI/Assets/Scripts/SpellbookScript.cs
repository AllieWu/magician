using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookScript : MonoBehaviour
{
    public GameObject[] prefabs = null;  // Array of prefab pages
    public GameObject currentPage = null; // Currently displayed page
    public GameObject parent = null;  // Spellbook Canvas is parent of pages
    public Animator anim = null;  // Used to call Animator Controller triggers


    /* Based off of input, changes spellbook page */
    void InstantiateAndDestroy(int pageNum)
    {
        // set up new page -> animate old one leaving -> snow new one -> destroy old
        GameObject currentPage_new = null;

        // animate old one leaving, wait 2 seconds, destroy object
        anim.SetTrigger("Flip");

        if (pageNum == 0)
        {
            // Spawn new page, set up relationships and scale
            currentPage_new = Instantiate(prefabs[0], transform.position, transform.rotation);
            print("0... length:" + prefabs.Length);
        }
        else if (pageNum == 1) {
            currentPage_new = Instantiate(prefabs[1], transform.position, transform.rotation);
            print("1... length:" +prefabs.Length);
        }
        currentPage_new.transform.SetParent(parent.transform);
        currentPage_new.transform.localScale = new Vector3(1, 1, 1);
        parent.transform.localScale = new Vector3(1, 1, 1);

        // Destroy old page and set up new
        Destroy(currentPage, .5f);
        currentPage = currentPage_new;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        print(prefabs.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // For development, using 0/1 to trigger page flips - should be a button
        if (Input.GetKeyDown("0"))
        {
            print("Pressed 0");
            InstantiateAndDestroy(0);
        }
        else if (Input.GetKeyDown("1"))
        {
            print("Pressed 1");
            InstantiateAndDestroy(1);
        }
    }
}
