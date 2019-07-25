using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Renderer from the GameObject
        
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.red);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
