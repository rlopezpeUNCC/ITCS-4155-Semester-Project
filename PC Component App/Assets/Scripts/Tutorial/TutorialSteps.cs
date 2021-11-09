using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Currently attached to Canvas

public class TutorialSteps : MonoBehaviour
{
    [SerializeField]
    GameObject appManager;
    TutorialPopupManager popUpMgr;
    string[,] tutSteps = new string[,] {{"Hey there!", "Welcome to Component Comparator! Let's take a quick tour.", },
                                        {"This is the computer.", "It's made of a bunch of parts you can click on (and, later, replace with new ones). Try right-clicking on the GPU (labelled MSI)!"},
                                        {"Component Details", "Right-clicking a part opens the description. When you start customizing, you'll see part stats here. Click that arrow on the right to hide the description."},
                                        {"Moving On", "Now, check out this button on the left."},
                                        {"Table of Contents", "This list gives you all the parts in the system. It also helps you see hidden parts! Try clicking the checkbox next to \"CPU Cooling\""},
                                        {"Hiding Parts", "Now you can see the CPU clearly. (BTW, right-clicking a part's name on the list also shows its info). Almost done! Close the Table of Contents with the arrow button."},
                                        {"Rotation", "If you still need a better view, you can rotate the computer by left-clicking. Try to find the case cooling fan by rotating, then right-click on it."},
                                        {"That's about it!", "If this view doesn't suit your fancy, you can zoom in and out with the scroll wheel, too. If you ever get lost, hit Reset View at the bottom and zoom accordingly."},
                                        {"Finished!", "That's everything you need to know for now! We don't have an exit button/feature yet, so I guess you're trapped here now..."}};
    float[,] tutStepCoords = new float[,] {{0,0}, {0,-410}, {0,0}, {-400,0}, {-400,-250}, {300,200}, {300,-150}, {300,-250}, {0,0}};
    int stepNum;
    float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set counter to start position and simply future references to TutorialPopupManager to save resources
        stepNum = 0;
        popUpMgr = appManager.GetComponent<TutorialPopupManager>();
        //gets delay to make sure its synced
        delay = popUpMgr.GetDelay();
        // Start tutorial sequence
        NextPopUp();
    }

    // Create next popup in the tutorial sequence
    void NextPopUp() {
        popUpMgr.CreatePopup(tutSteps[stepNum,0], tutSteps[stepNum,1], tutStepCoords[stepNum,0], tutStepCoords[stepNum,1], true);
        //Starts coroutine for retrieving button
        StartCoroutine(SetUpButton());
        stepNum++;
    }
    
    // Called when popup box is closed
    // If there is more tutorial left, call NextPopUp
    void PopUpClosed(Button popBtn) {
        if (stepNum < tutSteps.GetLength(0)) {
            NextPopUp();
        }
    }
    //Sets up button listener after delay. 
    //Since the pop up is created after a delay, this ensure it doesn't try to retrieve the button before it is created
    IEnumerator SetUpButton() {
        yield return new WaitForSeconds(delay);
        Button popBtn = popUpMgr.getPopUpButton();
        popBtn.onClick.AddListener(delegate {
            PopUpClosed(popBtn);
        });
    }
}
