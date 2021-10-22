using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    Material startColor;
    public Material mouseOverColor;
    GameObject oldComponent;

    public void objectSelected(GameObject component)
    {
        startColor = component.GetComponentInChildren<Renderer>().sharedMaterial;
        Renderer[] children = component.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children) 
        {
            rend.sharedMaterial = mouseOverColor;
        }

        objectDeselected(component);
    }

    private void objectDeselected(GameObject component)
    {
        Renderer[] children = oldComponent.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            rend.sharedMaterial = startColor;
        }
        oldComponent = component;

    }
    // Start is called before the first frame update
    void Start()
    {
        oldComponent = new GameObject();
        //rend = getcomponent<renderer>();
        //rend.enabled = true;
        //rend.sharedmaterial = startcolor;
    }
}

  
