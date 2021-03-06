using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
// Currently attached to ToCPanel
// Uses foreach code from https://forum.unity.com/threads/need-help-with-toggle.450210/#post-2913916

public class TableButtons : MonoBehaviour
{
    [SerializeField]
    ComponentMenu menu;     // lets us use ComponentMenu functions
    [SerializeField]
    Animator arrowAnimator;
    Animator animator;
    List<Button> tocButtons;    // list of buttons in ToC
    // from TableCheckBoxes: public Dictionary<string, Transform> tocParts;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>(); 
        // Make list of each Button in ToCPanel
        tocButtons = GetComponentsInChildren<Button>().ToList();        
        // Add listener to each Button to know when clicked
        foreach(Button thisButton in tocButtons) {
            if (thisButton.name != "ToCShowHide") {
                thisButton.onClick.AddListener(delegate {
                    ButtonClicked(thisButton);
                });
            }
           // print("Listener added for button " + thisButton.name);
        }
    }

    void ButtonClicked(Button thisButton) {
        //print("Button clicked for " + thisButton.GetComponentInParent<Toggle>().name);      
        menu.DetailSetup(thisButton.GetComponentInParent<Toggle>().name);
    }

    public void OpenCloseMenu() {
        animator = gameObject.GetComponent<Animator>();        
        bool isOpen = animator.GetBool("open");
        animator.SetBool("open", !isOpen);
        arrowAnimator.SetBool("open", isOpen);

        FindObjectOfType<AudioManager>().Play("PanelOpened");
    }
}
