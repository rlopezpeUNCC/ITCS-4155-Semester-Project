using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Material startColor;
    public Material mouseOverColor;
    Renderer rend;

    void OnMouseEnter()
    {
        rend.sharedMaterial = mouseOverColor;
    }

    private void OnMouseExit()
    {
        rend.sharedMaterial = startColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = startColor;
    }
}

  
