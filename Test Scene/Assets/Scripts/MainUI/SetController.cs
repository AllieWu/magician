using UnityEngine;
using UnityEngine.EventSystems;

public class SetController : MonoBehaviour
{
    public Canvas setcontainer = null;  // the hierachy object that holds the sets
    private static GameObject spellsPage = null;
    private static GameObject invPage = null;
    private static GameObject mapPage = null;
    private static GameObject questsPage = null;
    private GameObject[] pages = { };

    private void Start()
    {
        spellsPage = setcontainer.transform.Find("DefaultSet").gameObject;
        invPage = setcontainer.transform.Find("InvSet").gameObject;
        questsPage = setcontainer.transform.Find("QuestSet").gameObject;
        mapPage = setcontainer.transform.Find("MapSet").gameObject;

        //if (spellsPage != null)
          //  Debug.Log("SpellsPage found");

        spellsPage.SetActive(false);
        invPage.SetActive(false);
        mapPage.SetActive(false);
        questsPage.SetActive(false);

        pages = new GameObject[] { spellsPage, invPage, questsPage, mapPage };
    }

    public int GetCurrentSet()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].activeSelf)
                return i;
        }
        return 0;
    }

    // updates the current ui set displayed in the condensed ui
    public void SetCurrentSet(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            bool active = i == index ? true : false;
            pages[i].SetActive(active);
        }
    }
}
