using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
// Currently attached to ToCPanel
// Uses foreach code from https://forum.unity.com/threads/need-help-with-toggle.450210/#post-2913916

public class TableCheckBoxes : MonoBehaviour
{
    private List<Toggle> tocToggles;

    // Start is called before the first frame update
    void Start()
    {
        // Make list of each Toggle in ToCPanel
        tocToggles = GetComponentsInChildren<Toggle>().ToList();

        // Add listener to each Toggle to know when un/checked
        foreach(Toggle thisToggle in tocToggles) {
            thisToggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(thisToggle);
            });
           // print("Listener added for checkbox " + thisToggle.name);
        }
    }

    // TODO: Show/hide computer part when its respective toggle is clicked
    void ToggleValueChanged(Toggle thisToggle)
    {
        print("Checkbox " + thisToggle.name + " state = " + thisToggle.isOn);
    }
}
