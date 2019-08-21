using UnityEngine;
using UnityEngine.EventSystems;

public class QuestSetController : MonoBehaviour
{
    public GameObject[] scrollviews = null;
    public GameObject scrollcontainer = null;
    private GameObject currentscrollview = null;

    public void SetScrollView(int index)
    {
        Destroy(currentscrollview);
        currentscrollview = Instantiate(scrollviews[index], scrollcontainer.transform);
        currentscrollview.transform.localScale = new Vector3(1, 1, 1);
    }

    private void Start()
    {
        currentscrollview = Instantiate(scrollviews[0], scrollcontainer.transform);
        currentscrollview.transform.localScale = new Vector3(1, 1, 1);
    }
}
