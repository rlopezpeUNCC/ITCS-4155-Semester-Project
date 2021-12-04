using UnityEngine;
using System;
using System.Collections.Generic;

public class CompatabilityChecker : MonoBehaviour {
    [SerializeField]
    GameObject motherboard, ram, cpu, storage;
    List<string> motherboardsCPU1 = new List<string> {"ASUS PRIME B550M CSM AM4 (Ryzen 3000 Supported) Motherboard", "MSI MPG X570 Gaming Edge WiFi AM4 (Ryzen 3000 Ready) Motherboard", "MSI MPG X570 GAMING PLUS ATX Motherboard - Socket AM4"};
    List<string> motherboardsCPU2 = new List<string> {"ASUS PRIME B460-PLUS LGA 1200 (Intel 10th Gen) Motherboard", "ASUS TUF GAMING Z490-PLUS WiFi LGA 1200 (Intel 10th Gen)"};
    List<string> motherboardsCPU3 = new List<string> {"ASUS TUF B360M Plus Gaming LGA1151 Intel B360 Intel Motherboard"};
    List<string> motherboardsCPU4 = new List<string> {"MSI MPG Z390 GAMING PLUS LGA1151 (Intel 8th and 9th Gen) Mothe", "Asus TUF Z390-PLUS Gaming LGA1151 (Intel 8th and 9th Gen) Inte", "MSI MPG Z390 Gaming Edge AC LGA1151 (Intel 8th and 9th Gen) Wi", "ASUS ROG STRIX Z390-H Gaming LGA1151 (Intel 8th and 9th Gen) Intel Motherboard", "Asus PRIME B365M-A LGA1151 (Intel 8th and 9th Gen) Intel Mothe"};
    List<string> motherboardsRam = new List<string> {"ASUS H81M-C/CSM LFA", "ASUS B85M-C/CSM LGA 1150 intel Motherboard"};
    List<string> CPUmotherboards4 = new List<string> {"Intel Core i5-9400 Coffee Lake 6-Core 2.9 GHz (4.1Hz Turbo) LG.", "Intel Core i9-9900K Coffee Lake 8-Core 3.6 GHz (5.0Hz Turbo) L", "Intel Core i7-9700K Coffee Lake 8-Core 3.6 GHz (4.9Hz Turbo) L", "Intel Core i5-9600K Coffee Lake 6-Core 3.7 GHz (4.6Hz Turbo) L", "Intel Core i7-8700K Coffee Lake 6-Core 3.7 GHz (4.7 GHz Turbo)"};
    List<string> CPUmotherboards3 = new List<string> {"Intel Core i7-8700K Coffee Lake 6-Core 3.7 GHz (4.7 GHz Turbo)"};
    List<string> CPUmotherboards2 = new List<string> {"Intel Core i7-10700 Comet Lake 8-Core 2.9 GHz (4.8 GHz Turbo)", "Intel Core i5-10600k Comet Lake 6-Core 4.1 GHz (4.8 GHz Turbo)", "Intel Core i5-10400 Comet Lake 6-Core 2.9 GHz (4.3 GHz Turbo)"};
    List<string> CPUmotherboards1 = new List<string> {"AMD Ryzen 7 3700X 3.8 GHz Eight-Core AM4 Processor"};
    List<string> motherboardStorage1 = new List<string> {"MSI A88XM", "ASUS H81M-C/CSM LFA 1150 Intel Motherboard", "ASUS B85M-C/CSM LGA 1150 intel Motherboard"};
    List<string> storageMotherboard1 = new List<string> {"HP M700"};
    public void CheckCompatability(string[,] selectedModels, int index) {
        List<GameObject> incompatible = new List<GameObject>();
        switch(index) {
            //motherboard
            case(6):
                if (selectedModels[index, 1] == "Default") break;
                //checking ram
                if (selectedModels[8, 1].Contains("DDR3")) {
                    if (!selectedModels[6, 1].Contains(motherboardsRam[0]) && !selectedModels[6, 1].Contains(motherboardsRam[1])) {
                        incompatible.Add(ram);
                    }
                } else if (selectedModels[8, 1].Contains("DDR4")) {
                    print("DDR4");
                    if (selectedModels[6, 1].Contains(motherboardsRam[0]) || selectedModels[6, 1].Contains(motherboardsRam[1])) {
                        incompatible.Add(ram);
                    }
                }
                //checking CPU
                foreach (string model in motherboardsCPU1) {
                    if (selectedModels[index, 1].Contains(model)) {
                        bool compatable = false;
                        foreach (string cpuModel in CPUmotherboards1) {
                            if (selectedModels[1, 1].Contains(cpuModel)) compatable = true;
                        }
                        if (!compatable) incompatible.Add(cpu);
                    }
                }
                foreach (string model in motherboardsCPU2) {
                    if (selectedModels[index, 1].Contains(model)) {
                        bool compatable = false;
                        foreach (string cpuModel in CPUmotherboards2) {
                            if (selectedModels[1, 1].Contains(cpuModel)) compatable = true;
                        }
                        if (!compatable) incompatible.Add(cpu);
                    }
                }
                foreach (string model in motherboardsCPU3) {
                    if (selectedModels[index, 1].Contains(model)) {
                        if (!selectedModels[1, 1].Contains("Intel Core i7-8700K Coffee Lake 6-Core 3.7 GHz (4.7 GHz Turbo)")) {
                            incompatible.Add(cpu);
                        }
                    }
                }
                foreach (string model in motherboardsCPU4) {
                    if (selectedModels[index, 1].Contains(model)) {
                        bool compatable = false;
                        foreach (string cpuModel in CPUmotherboards4) {
                            if (selectedModels[1, 1].Contains(cpuModel)) compatable = true;
                        }
                        if (!compatable) incompatible.Add(cpu);
                    }
                }
                //checking storage
                if (selectedModels[5, 1] != "Default") {
                    foreach (string model in storageMotherboard1) {    
                        if (selectedModels[5, 1].Contains(model)) {                
                            bool compatable = false;
                            foreach (string motherboard in motherboardStorage1) {
                                if (selectedModels[index, 1].Contains(motherboard)) compatable = true;
                            }
                            if (!compatable) incompatible.Add(storage);
                        } else {
                            foreach (string motherboard in motherboardStorage1) {
                                if (selectedModels[index, 1].Contains(motherboard)) incompatible.Add(storage);
                            }
                        }
                    }
                }
                gameObject.GetComponent<Highlight>().IncompatableObjects(incompatible);
                
                break;
            //RAM
            case(8):
                if (selectedModels[index, 1] == "Default") break;
                //print("Checking RAM<" + selectedModels[index, 1] + "> and Motherboard<" + selectedModels[6, 1] + "> compatability");
                //checking motherboards
                if (selectedModels[index, 1].Contains("DDR3")) {
                    //print("DDR3 RAM");
                    if (!selectedModels[6, 1].Contains(motherboardsRam[0]) && !selectedModels[6, 1].Contains(motherboardsRam[1])) {
                        incompatible.Add(motherboard);
                        //print("NOT DDR3 Motherboard");
                    }
                } else if (selectedModels[index, 1].Contains("DDR4")) {
                    print("DDR4");
                    if (selectedModels[6, 1].Contains(motherboardsRam[0]) || selectedModels[6, 1].Contains(motherboardsRam[1])) {
                        incompatible.Add(motherboard);
                        //print("NOT DDR4 Motherboard");
                    }
                }
                
                gameObject.GetComponent<Highlight>().IncompatableObjects(incompatible);
                break;
            //CPU
            case(1):
                break;

        }
    }

    public void ClearIncompatablities() {
        gameObject.GetComponent<Highlight>().ClearIncompatablities();
    }

    
}
