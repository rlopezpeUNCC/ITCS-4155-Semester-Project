using UnityEngine;
using System;
using System.Collections.Generic;

public class CompatabilityChecker : MonoBehaviour {
    [SerializeField]
    GameObject motherboard, ram, cpu, storage;
    List<string> motherboards = new List<string> {"ASUS H81M-C/CSM LFA", "ASUS B85M-C/CSM LGA 1150 intel Motherboard"};
    public void CheckCompatability(string[,] selectedModels, int index) {
        List<GameObject> incompatible = new List<GameObject>();
        switch(index) {
            //motherboard
            case(6):
                //checking ram
                Debug.Log("Checking Motherboard<" + selectedModels[index, 1] + ">; RAM<" + selectedModels[8, 1] + ">");
                foreach (string model in motherboards) {
                    if (selectedModels[index, 1].Contains(model)) {
                        if (!selectedModels[8, 1].Contains("DDR3") && selectedModels[8, 1] != "Default") {
                            incompatible.Add(ram);
                            Debug.Log("Incompatable RAM<" + selectedModels[8, 1] + ">;  + Motherboard<" + model + ">");
                        } 
                        break;
                    } else if (selectedModels[8, 1].Contains("DDR3")) {
                        Debug.Log("Incompatable Motherboard<" + model + ">; RAM<" + selectedModels[8, 1] + ">");
                        incompatible.Add(ram);
                        break;
                    }
                }
                if (incompatible.Count > 0) {
                    //Debug.Log();
                    gameObject.GetComponent<Highlight>().IncompatableObjects(incompatible);
                }
                break;
        }
    }

    
}
