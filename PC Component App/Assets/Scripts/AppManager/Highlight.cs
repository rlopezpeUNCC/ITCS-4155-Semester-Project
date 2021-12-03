using UnityEngine;
using System.Collections.Generic;
public class Highlight : MonoBehaviour {
    GameObject oldComponent;
    Color baseColor, highlightColor;
    List<GameObject> IncompatableComps = new List<GameObject>();
    [SerializeField]
    // Start is called before the first frame update
    void Start() {
        oldComponent = new GameObject();
        highlightColor = new Color(1, .9411764705882353f ,0, 1);
    }

    public void ObjectSelected(GameObject component) {
        if (component != null) {
            Renderer[] children = component.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) 
            {
                rend.material.SetFloat("_HighLightEnabled", 1);
            }
        } else {
            Debug.Log("Hit Null: ");
        }
    }

    public void ObjectDeselected(GameObject component)
    {
        if (component != null) {
        //if (oldComponent != component) {
            Renderer[] children = oldComponent.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                rend.material.SetFloat("_HighLightEnabled", 0);
            }
            oldComponent = component;
        }
    }

    public void IncompatableObjects(List<GameObject> components) {        
        ClearIncompatablities();
        if (components != null) {
            foreach (GameObject component in components) {
                Renderer[] children = component.GetComponentsInChildren<Renderer>();
                //Debug.Log("highlighting: " + component.name + ". Children: " + children.Length);
                foreach (Renderer rend in children) {
                    rend.material.SetColor("_HighlightColor", Color.red);
                    rend.material.SetFloat("_HighLightEnabled", 1);
                }
            }
        } 
        IncompatableComps = components;
    }

    public void ClearIncompatablities() {
        //Debug.Log("clearing");
        if (IncompatableComps != null) {
            foreach (GameObject component in IncompatableComps) {
                Renderer[] children = component.GetComponentsInChildren<Renderer>();
                //Debug.Log("highlighting: " + component.name + ". Children: " + children.Length);
                foreach (Renderer rend in children) {
                    if (oldComponent == component) {
                        rend.material.SetColor("_HighlightColor", highlightColor);
                    }
                    if (rend.material.GetColor("_HighlightColor") == Color.red) {
                        rend.material.SetColor("_HighlightColor", highlightColor);
                        rend.material.SetFloat("_HighLightEnabled", 0);
                    }
                }
            }
        }
    }
    
}

  
