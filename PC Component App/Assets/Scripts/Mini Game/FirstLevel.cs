using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    public GameObject ramHandler, cpuHandler, cpuFanHandler, gpuHandler;
    public Color wrongColor, rightColor;
    // Start is called before the first frame update
    void Start()
    {
        ramHandler.SetActive(false);
        cpuFanHandler.SetActive(false);
        cpuHandler.SetActive(false);
        gpuHandler.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform)
                {
                    ChangeButtons(hit.collider.transform.gameObject.name);
                }
            }
        }
    }

    public void ChangeButtons(string component)
    {
        if (component == "CPU") 
        {
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(false);
            gpuHandler.SetActive(false);
            cpuHandler.SetActive(true);

        }
        else if(component == "CPU Fan")
        {
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(true);
        }
        else if(component == "RAM")
        {
            cpuFanHandler.SetActive(false);
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(true);
        }
        else if(component == "GPU")
        {
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(false);
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        
    }
}
