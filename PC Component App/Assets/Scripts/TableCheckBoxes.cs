using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
// Currently attached to ToCPanel
// Uses foreach code from https://forum.unity.com/threads/need-help-with-toggle.450210/#post-2913916
// TODO: Add code to update text for individual Toggles to show the partName of their respective Transform in tocParts.

public class TableCheckBoxes : MonoBehaviour
{
    private List<Toggle> tocToggles; // list of checkboxes in ToC
    public Dictionary<string, Transform> tocParts; // dictionary of parts named by each toggle

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
    }

    // Show/hide computer part when its respective toggle is clicked
    void ToggleValueChanged(Toggle thisToggle)
    {
        // Find the tocParts member with the same name as the clicked toggle, then gather its children
        Renderer[] lChildRenderers=tocParts[thisToggle.name].GetComponentsInChildren<Renderer>();

        // Show (or hide) each child until the part is fully shown/hidden
        if (thisToggle.isOn) { // Checked (Show)
            foreach ( Renderer lRenderer in lChildRenderers)
            {
                lRenderer.enabled=true;
            }
        } else { // Unchecked (Hide)
            foreach ( Renderer lRenderer in lChildRenderers)
            {
                lRenderer.enabled=false;
            }
        }
        FindObjectOfType<AudioManager>().Play("ButtonClicked2");
        //print("Checkbox " + thisToggle.name + " state = " + thisToggle.isOn);
    }
}
