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
    }

    public void ObjectSelected(GameObject component)
    {
        if (component != null) {
            Renderer[] children = component.GetComponentsInChildren<Renderer>();
            //Debug.Log("highlighting: " + component.name + ". Children: " + children.Length);
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
    
}

  
