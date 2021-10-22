using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
// Currently attached to ToCPanel
// Uses foreach code from https://forum.unity.com/threads/need-help-with-toggle.450210/#post-2913916

public class TableButtons : MonoBehaviour
{
    private List<Button> tocButtons; // list of buttons in ToC
    // from TableCheckBoxes: public Dictionary<string, Transform> tocParts;

    // Start is called before the first frame update
    void Start()
    {
        // Make list of each Button in ToCPanel
        tocButtons = GetComponentsInChildren<Button>().ToList();

        // Add listener to each Button to know when clicked
        foreach(Button thisButton in tocButtons) {
            thisButton.onClick.AddListener(delegate {
                ButtonClicked(thisButton);
            });
           // print("Listener added for button " + thisButton.name);
        }
    }

    // TODO: Highlight computer part when its respective ToC Button is clicked
    void ButtonClicked(Button thisButton)
    {
        print("Button clicked for " + thisButton.GetComponentInParent<Toggle>().name);
    }
}
