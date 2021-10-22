using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class TableVisibility : MonoBehaviour
{
    [SerializeField]
    GameObject ToCPanel;

    private List<Button> allButtons;    // list of buttons under Canvas (why does unity work this way?)

    // Start is called before the first frame update
    void Start()
    {
        // Make list of each Button under Canvas
        allButtons = GetComponentsInChildren<Button>().ToList();

        // Try to find the right button, then add listener
        foreach(Button thisButton in allButtons) {
            //print("Looking at button " + thisButton.name);
            if (thisButton.name == "ToCShowHide") {
                thisButton.onClick.AddListener(delegate {
                    ButtonClicked(thisButton);
                });
                print("Listener added for button " + thisButton.name);
            }
        }
    }

    // On click, show/hide the ToC
    void ButtonClicked(Button btn)
    {
        print("Toggle clicked");
        ToCPanel.SetActive(!ToCPanel.activeSelf);
    }
}
