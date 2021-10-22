using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Material startColor;
    public Material mouseOverColor;

    public void objectSelected(GameObject component)
    {
        Renderer[] children = component.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children) 
        {
            rend.sharedMaterial = mouseOverColor;
        } 
    }

    private void OnMouseExit()
    {
       // rend.sharedMaterial = startColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        //rend = getcomponent<renderer>();
        //rend.enabled = true;
        //rend.sharedmaterial = startcolor;
    }
}

  
