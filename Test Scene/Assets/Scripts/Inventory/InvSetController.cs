using UnityEngine;
using UnityEngine.UI;

public class InvSetController : MonoBehaviour
{
    //public GameObject[] invcanvases = null;
    //public GameObject invcontainer = null;
    //private GameObject currentinv = null;

    public Text ItemDescContainer = null;

    //public void SetInventory(int index)
    //{
    //    Destroy(currentinv);
    //    currentinv = Instantiate(invcanvases[index], invcontainer.transform);
    //    currentinv.transform.localScale = new Vector3(1, 1, 1);
    //}

    private void Start()
    {
        //currentinv = Instantiate(invcanvases[0], invcontainer.transform);
        //currentinv.transform.localScale = new Vector3(1, 1, 1);
    }

    public void SelectItem(Item _item)
    {
        //ItemDescContainer.text = _item.GetDescription();
    }
}
