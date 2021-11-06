using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Shader startColor;
    public Shader mouseOverColor;
    GameObject oldComponent;
    Color baseColor;
    [SerializeField]
    Material[] mats = new Material[20];
    // Start is called before the first frame update
    void Start()
    {
        oldComponent = new GameObject();
        foreach (Material mat in mats)
        {
            baseColor = mat.GetColor("_BaseColor");
            mat.SetColor("_OutlineColor", baseColor);
        }
    }

    public void ObjectSelected(GameObject component)
    {
        
        Renderer[] children = component.GetComponentsInChildren<Renderer>();
        //Debug.Log("highlighting: " + component.name + ". Children: " + children.Length);
        foreach (Renderer rend in children) 
        {
            rend.material.SetColor("_OutlineColor", Color.yellow);
        }
    }

    public void ObjectDeselected(GameObject component)
    {
        //if (oldComponent != component) {
            Renderer[] children = oldComponent.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                baseColor = rend.material.GetColor("_BaseColor");
                rend.material.SetColor("_OutlineColor", baseColor);
            }
            oldComponent = component;
        // } else if (exception) {
        //     Renderer[] children = oldComponent.GetComponentsInChildren<Renderer>();
        //     foreach (Renderer rend in children)
        //     {
        //         baseColor = rend.material.GetColor("_BaseColor");
        //         rend.material.SetColor("_OutlineColor", baseColor);
        //     }
        //     oldComponent = component;
        // }
    }
    
}

  
