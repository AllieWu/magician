using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TierSelectButton : MonoBehaviour
{
    public int tier;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleClick()
    {

    }
}
