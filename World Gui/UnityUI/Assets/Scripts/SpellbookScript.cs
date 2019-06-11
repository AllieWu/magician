using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookScript : MonoBehaviour
{
    public GameObject[] prefabs = null;  // Array of prefab pages
    public GameObject currentPage = null; // Currently displayed page
    public GameObject parent = null;  // Spellbook Canvas is parent of pages
    GameObject newPage = null;

    /* Based off of input, changes spellbook page */
    void InstantiateAndDestroy(int pageNum)
    {
        // Spawn new page, set up relationships, and scale
        newPage = Instantiate(prefabs[pageNum], parent.transform);
        newPage.transform.localScale = new Vector3(1, 1, 1);
        parent.transform.localScale = new Vector3(1, 1, 1);

        // Animate page leaving and destroy
        currentPage.BroadcastMessage("Flip");
        Destroy(currentPage);
        currentPage = newPage;
    }

    // Update is called once per frame
    void Update()
    {

        // For development, using 0/1 to trigger page flips - should be a button
        if (Input.GetKeyUp("0"))
        {
            print("Pressed 0");
            InstantiateAndDestroy(0);
        }
        else if (Input.GetKeyUp("1"))
        {
            print("Pressed 1");
            InstantiateAndDestroy(1);
        }
    }

}

