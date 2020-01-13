using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildActivator : MonoBehaviour
{
    public void AbleChildren(bool onOrOff)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(onOrOff);
        }
    }
}
