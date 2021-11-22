using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using TMPro;
// Currently attached to ToCPanel
// Uses foreach code from https://forum.unity.com/threads/need-help-with-toggle.450210/#post-2913916
// TODO: Add code to update text for individual Toggles to show the partName of their respective Transform in tocParts.

public class TableCheckBoxes : MonoBehaviour
{
    List<Toggle> tocToggles; // list of checkboxes in ToC
    //List<Renderer> toggledComponents = new List<Renderer>();
    public Dictionary<string, Transform> tocParts; // dictionary of parts named by each toggle
    [SerializeField] 
    GameObject pcCase, cpu, cpuCooling, caseCooling, discDrives, gpu, storage, motherboard, psu, ram;

    bool caseDissolving, cpuDissolving, cpuCoolingDissolving, caseCoolingDissolving, discDrivesDissolving, gpuDissolving, storageDissolving, 
        motherboardDissolving, psuDissolving, ramDissolving;
    bool caseMaterializing, cpuMaterializing, cpuCoolingMaterializing, caseCoolingMaterializing, discDrivesMaterializing, gpuMaterializing, storageMaterializing, 
        motherboardMaterializing, psuMaterializing, ramMaterializing;

    // Start is called before the first frame update
    void Start()
    {
        // Make dictionary of parts in current computer
        GameObject parentComputer = GameObject.Find("Computer");
        tocParts = new Dictionary<string, Transform>();
        foreach (Transform child in parentComputer.transform)
        {
            tocParts.Add(child.name, child);
            // print("Added to tocParts: " + child.name);
        }

        // Make list of each Toggle in ToCPanel
        tocToggles = GetComponentsInChildren<Toggle>().ToList();

        // Add listener to each Toggle to know when un/checked
        foreach(Toggle thisToggle in tocToggles) {
            thisToggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(thisToggle);
            });
           // print("Listener added for checkbox " + thisToggle.name);
        }

        caseDissolving = cpuDissolving = cpuCoolingDissolving = caseCoolingDissolving = discDrivesDissolving = gpuDissolving = storageDissolving = 
            motherboardDissolving = psuDissolving = ramDissolving = false;
        caseMaterializing = cpuMaterializing = cpuCoolingMaterializing = caseCoolingMaterializing = discDrivesMaterializing = gpuMaterializing = storageMaterializing = 
            motherboardMaterializing = psuMaterializing = ramMaterializing = false;
    }

    // Show/hide computer part when its respective toggle is clicked
    void ToggleValueChanged(Toggle thisToggle)
    {
        // Find the tocParts member with the same name as the clicked toggle, then gather its children
        Renderer[] lChildRenderers=tocParts[thisToggle.name].GetComponentsInChildren<Renderer>();
        
        // Show (or hide) each child until the part is fully shown/hidden
        if (!thisToggle.isOn) { // Checked (Show)
            switch(thisToggle.name) {
                case("Case"):
                    caseDissolving = true;
                    caseMaterializing = false;
                    break;
                case("Case Cooling"):
                    caseCoolingDissolving = true;
                    caseCoolingMaterializing = false;
                    break;
                case("Motherboard"):
                    motherboardDissolving = true;
                    motherboardMaterializing = false;
                    break;
                case("CPU"):
                    cpuDissolving = true;
                    cpuCoolingMaterializing = false;
                    break;
                case("CPU Cooling"):
                    cpuCoolingDissolving = true;
                    cpuCoolingMaterializing = false;
                    break;
                case("RAM"):
                    ramDissolving = true;
                    ramMaterializing = false;
                    break;
                case("GPU"):
                    gpuDissolving = true;
                    gpuMaterializing = false;
                    break;
                case("Storage"):
                    storageDissolving = true;
                    storageMaterializing = false;
                    break;
                case("Disc Drives"):
                    discDrivesDissolving = true;
                    discDrivesMaterializing = false;
                    break;
                case("Power Supply"):
                    psuDissolving = true;
                    psuMaterializing = false;
                    break;
                default:
                    Debug.Log("Couldnt find: " + thisToggle.name);
                    break;
            }
            
        } else {
            switch(thisToggle.name) {
                case("Case"):
                    caseMaterializing = true;
                    caseDissolving = false;
                    break;
                case("Case Cooling"):
                    caseCoolingMaterializing = true;
                    caseCoolingDissolving = false;
                    break;
                case("Motherboard"):
                    motherboardMaterializing = true;
                    motherboardDissolving = false;
                    break;
                case("CPU"):
                    cpuMaterializing = true;
                    cpuDissolving = false;
                    break;
                case("CPU Cooling"):
                    cpuCoolingMaterializing = true;
                    cpuCoolingDissolving = false;
                    break;
                case("RAM"):
                    ramMaterializing = true;
                    ramDissolving = false;
                    break;
                case("GPU"):
                    gpuMaterializing = true;
                    gpuDissolving = false;
                    break;
                case("Storage"):
                    storageMaterializing = true;
                    storageDissolving = false;
                    break;
                case("Disc Drives"):
                    discDrivesMaterializing = true;
                    discDrivesDissolving = false;
                    break;
                case("Power Supply"):
                    psuMaterializing = true;
                    psuDissolving = false;
                    break;
                default:
                    Debug.Log("Couldnt find: " + thisToggle.name);
                    break;
            }
        }
        FindObjectOfType<AudioManager>().Play("ButtonClicked2");
        //print("Checkbox " + thisToggle.name + " state = " + thisToggle.isOn);
    }

    void Update() {
        //case off
        if (caseDissolving) {
            Renderer[] children = pcCase.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    BoxCollider[] temp = pcCase.GetComponents<BoxCollider>();
                    foreach(BoxCollider box in temp) {
                        box.enabled = false;
                    }
                    caseDissolving = false;
                }
            }
        }
        //case on
        if (caseMaterializing) {
            BoxCollider[] temp = pcCase.GetComponents<BoxCollider>();
            foreach(BoxCollider box in temp) {
                box.enabled = true;
            }
            Renderer[] children = pcCase.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    caseMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //cpu off
        if (cpuDissolving) {
            Renderer[] children = cpu.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("New Material")) {
                    if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                        rend.material.SetFloat("_DissolveEnabled", 1);
                    } else if (rend.material.GetFloat("_Step") < .8) {                    
                        rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                    } else {
                        cpu.GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("AMD").GetComponent<TextMeshPro>().text = "";
                        GameObject.Find("RYZEN").GetComponent<TextMeshPro>().text = "";
                        cpuDissolving = false;
                    }
                }
            }
        }
        //cpu on
        if (cpuMaterializing) {
            cpu.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = cpu.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("New Material")) {
                    if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                        rend.material.SetFloat("_DissolveEnabled", 1);
                    } else if (rend.material.GetFloat("_Step") > 0) {                    
                        rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                    } else {
                        GameObject.Find("AMD").GetComponent<TextMeshPro>().text = "AMD";
                        GameObject.Find("RYZEN").GetComponent<TextMeshPro>().text = "RYZEN";
                        cpuMaterializing = false;
                        rend.material.SetFloat("_DissolveEnabled", 0);
                    }
                }
            }
        }
        //cpu cooling off
        if (cpuCoolingDissolving) {
            Renderer[] children = cpuCooling.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    cpuCooling.GetComponent<BoxCollider>().enabled = false;
                    cpuCoolingDissolving = false;
                }
            }
        }
        //cpu cooling on
        if (cpuCoolingMaterializing) {
            cpuCooling.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = cpuCooling.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    cpuCoolingMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //case cooling off
        if (caseCoolingDissolving) {
            Renderer[] children = caseCooling.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                //Debug.Log("going through rend");
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    caseCooling.GetComponent<BoxCollider>().enabled = false;
                    caseCoolingDissolving = false;
                }
            }
        }
        //case cooling on
        if (caseCoolingMaterializing) {
            caseCooling.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = caseCooling.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    caseCoolingMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //disc drives off
        if (discDrivesDissolving) {
            Renderer[] children = discDrives.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    discDrives.GetComponent<BoxCollider>().enabled = false;
                    discDrivesDissolving = false;
                }
            }
        }
        //disc drives on
        if (discDrivesMaterializing) {
            discDrives.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = discDrives.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    discDrivesMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //GPU off
        if (gpuDissolving) {
            Renderer[] children = gpu.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    gpu.GetComponent<BoxCollider>().enabled = false;
                    gpuDissolving = false;
                }
            }
        }
        //GPU on
        if (gpuMaterializing) {
            gpu.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = gpu.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    gpuMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //storage off
        if (storageDissolving) {
            Renderer[] children = storage.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    storage.GetComponent<BoxCollider>().enabled = false;
                    storageDissolving = false;
                }
            }
        }
        //storage on
        if (storageMaterializing) {
            storage.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = storage.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    storageMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //motherboad off
        if (motherboardDissolving) {
            Renderer[] children = motherboard.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    motherboard.GetComponent<BoxCollider>().enabled = false;
                    motherboardDissolving = false;
                }
            }
        }
        //motherboad on
        if (motherboardMaterializing) {
            motherboard.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = motherboard.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    motherboardMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //PSU off
        if (psuDissolving) {
            Renderer[] children = psu.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    psu.GetComponent<BoxCollider>().enabled = false;
                    psuDissolving = false;
                }
            }
        }
        //PSU on
        if (psuMaterializing) {
            psu.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = psu.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    psuMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
        //Ram off
        if (ramDissolving) {
            Renderer[] children = ram.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_DissolveEnabled") == 0) {
                    rend.material.SetFloat("_DissolveEnabled", 1);
                } else if (rend.material.GetFloat("_Step") < .8) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")+Time.deltaTime);
                } else {
                    ram.GetComponent<BoxCollider>().enabled = false;
                    ramDissolving = false;
                }
            }
        }
        //Ram on
        if (ramMaterializing) {
            ram.GetComponent<BoxCollider>().enabled = true;
            Renderer[] children = ram.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children) {
                if (rend.material.name.Contains("Lit")) {
                    Debug.Log(rend.gameObject.name);
                }
                if (rend.material.GetFloat("_Step") > 0) {                    
                    rend.material.SetFloat("_Step", rend.material.GetFloat("_Step")-Time.deltaTime);
                } else {
                    ramMaterializing = false;
                    rend.material.SetFloat("_DissolveEnabled", 0);
                }
            }
        }
    }
    
}
