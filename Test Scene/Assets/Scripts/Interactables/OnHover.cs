using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour
{
    public GameObject triggerObject;

    void OnMouseOver() // This Function for  Mouse Over a Mesh or GUIContent
    {
        triggerObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        triggerObject.SetActive(false);
    }
}
