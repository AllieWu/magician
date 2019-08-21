using UnityEngine;
using UnityEngine.EventSystems;

public class SetController : MonoBehaviour
{
    public GameObject[] prefabsets = null;  // set of uis to condense into one
    public Canvas setcontainer = null;  // the hierachy object that holds the sets
    private GameObject currentset = null;  // current set under set container 
    private GameObject tempSet = null;

    // Testing some stuff
    private Player myPlayer = null;

    // updates the current ui set displayed in the condensed ui
    public void SetCurrentSet(int index)
    {
        tempSet = Instantiate(prefabsets[index], setcontainer.transform);
        tempSet.transform.localScale = new Vector3(1, 1, 1);
        Destroy(currentset);

        currentset = tempSet;
    }

    private void Start()
    {
        // At the start, set up currentset as the GameObject component of our setcontainer object
        currentset = setcontainer.GetComponent<GameObject>();
    }
}
