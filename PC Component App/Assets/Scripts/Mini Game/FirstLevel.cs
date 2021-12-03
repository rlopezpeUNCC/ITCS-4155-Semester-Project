using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevel : MonoBehaviour
{
    public GameObject cpu, cpuFan, ram, gpu, ramHandler, cpuHandler, cpuFanHandler, gpuHandler;

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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
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
        else if (component == "CPU Fan")
        {
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(true);
        }
        else if (component == "RAM")
        {
            cpuFanHandler.SetActive(false);
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(true);
        }
        else if (component == "GPU")
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

    public void ButtonClicked(Button thisButton)
    {
        if (thisButton.name == "Correct")
        {
            print("Correct");
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(false);
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            print("Parent name: " + thisButton.transform.parent.name);
            string parentName = thisButton.transform.parent.name;
            if (parentName == "CPU Button Canvas")
            {
                cpu.transform.position = new Vector3(-1.21f, .07f, 6.275f);
            }
            else if(parentName == "RAM Button Canvas")
            {
                ram.transform.position = new Vector3(.82f, .08f, 7.37f);
            }
            else if(parentName == "CPU Fan Button Canvas")
            {
                cpuFan.transform.position = new Vector3(-1.21f, .07f, 6.5f);
            }
            else if(parentName == "GPU Button Canvas")
            {
                gpu.transform.position = new Vector3(-0.3f, -.04f, 5.2f);
            }
        }
    }
}

