using UnityEngine;
using System.Collections.Generic;
public class DropDown : MonoBehaviour {
    [SerializeField]
    TMPro.TMP_Dropdown dropdown;
    [SerializeField]
    ComponentMenu componentMenu;
    string selectedComponent = "Default";
    void Update() {
        if (componentMenu.GetName() != selectedComponent) {
            selectedComponent = componentMenu.GetName();
            UpdateList();
        }
    }
    
    void UpdateList() {
        dropdown.ClearOptions();
        List<string> PCcase = new List<string> { "Case default"};
        switch(selectedComponent) {
            case("Case"):
                dropdown.AddOptions(PCcase);
                break;
            default:

                break;
        }
    }
   
}
