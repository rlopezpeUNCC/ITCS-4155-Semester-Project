using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Currently attached to Canvas

public class TutorialSteps : MonoBehaviour
{
    // to simplify calls to TutorialPopupManager
    [SerializeField]
    GameObject appManager;
    TutorialPopupManager popUpMgr;
    // for alternative listener solutions
    [SerializeField]
    GameObject gpuObj, caseCoolingObj;
    [SerializeField]
    Animator compMenuAnimator, tocAnimator;
    [SerializeField]
    Toggle cpuCoolingToggle;
    // Tutorial procedure data
    string[,] tutSteps = new string[,] {{"Hey there!", "Welcome to Component Comparator! Let's take a quick tour.", },
                                        {"This is the computer.", "It's made of a bunch of parts you can click on (and, later, replace with new ones). Try right-clicking on the GPU (labelled MSI)!"},
                                        {"Component Details", "Right-clicking a part opens the description. When you start customizing, you'll see part stats here. Click that arrow on the right to hide the description."},
                                        {"Moving On", "Now, check out this button on the left."},
                                        {"Table of Contents", "This list gives you all the parts in the system. It also helps you see hidden parts! Try clicking the toggle next to \"CPU Cooling\"."},
                                        {"Hiding Parts", "Now you can see the CPU clearly. (BTW, right-clicking a part's name on the list also shows its info). Almost done! Close the Table of Contents with the arrow button."},
                                        {"Rotation", "If you still need a better view, you can rotate the computer by left-clicking. Try to find the case cooling fan by rotating, then right-click on it."},
                                        {"That's about it!", "If this view doesn't suit your fancy, you can zoom in and out with the scroll wheel, too. If you ever get lost, hit Reset View at the bottom and zoom accordingly."},
                                        {"Finished!", "That's everything you need to know for now! Feel free to mess around until you wanna switch to the regular mode."}};
    float[,] tutStepCoords = new float[,] {{0,0}, {0,-410}, {0,0}, {-400,0}, {-400,-250}, {300,200}, {300,-150}, {300,-250}, {0,0}};
    bool[] useOkBtn = new bool[] {true, false, false, false, false, false, false, true, true};
    // Tutorial functional variables
    int stepNum;
    float delay;
    bool checkForHighlight, checkForMenu, checkToggle;
    int menuCheckType; // 0 = ToC open, 1 = ToC closed, 2 = ComponentMenu open, 3 = ComponentMenu closed
    Renderer goalObjRenderer;
    
    // Start is called before the first frame update
    void Start() {
        // Set counter to start position
        stepNum = 0;
        // simplify future references to TutorialPopupManager to save resources
        popUpMgr = appManager.GetComponent<TutorialPopupManager>();
        // Ensure checkForHighlight, checkForMenu, and checkToggle are disabled
        checkForHighlight = false;
        checkForMenu = false;
        checkToggle = false;
        // gets delay to make sure its synced
        delay = popUpMgr.GetDelay()+.01f;
        // Start tutorial sequence
        NextPopUp();
    }

    // Update is called each frame (used as a makeshift alternative listener, see SetUpButton)
    void Update() {
        if (checkForHighlight) { // When current step requires clicking an object
            if (goalObjRenderer.material.GetFloat("_HighLightEnabled") == 1) { // object was selected, move to next step
                checkForHighlight = false;
                NextPopUp();
            } else {
                // object wasn't selected -- leaving this space here in case future changes make use of it
            }
        } else if (checkForMenu) { // When current step requires closing a menu
            switch (menuCheckType) {
                case 0: // ToC open
                    if (tocAnimator.GetBool("open")) {
                        checkForMenu = false;
                        NextPopUp();
                    }
                    break;
                case 1: // ToC closed
                    if (!tocAnimator.GetBool("open")) {
                        checkForMenu = false;
                        NextPopUp();
                    }
                    break;
                case 2: // ComponentMenu open -- not used
                    if (compMenuAnimator.GetBool("open")) {
                        checkForMenu = false;
                        NextPopUp();
                    }
                    break;
                case 3: // ComponentMenu closed
                    if (!compMenuAnimator.GetBool("open")) {
                        checkForMenu = false;
                        NextPopUp();
                    }
                    break;
                default:
                    print("ERROR: menuCheckType has a bad value " + menuCheckType);
                    break;
            }
        } else if (checkToggle) { // When current step requires closing a toggle
            if (!cpuCoolingToggle.isOn) {
                checkToggle = false;
                NextPopUp();
            }
        }
    }

    // Called when a popup box with an OK button is closed OR when an alt listening condition is fulfilled
    // Create next popup in the tutorial sequence if there is more tutorial left
    void NextPopUp() {
        if (stepNum < tutSteps.GetLength(0)) {
            popUpMgr.CreatePopup(tutSteps[stepNum,0], tutSteps[stepNum,1], tutStepCoords[stepNum,0], tutStepCoords[stepNum,1], useOkBtn[stepNum]);
            //Starts coroutine for retrieving button
            StartCoroutine(SetUpButton());
            stepNum++;
        }
    }

    //Sets up button listener (or alternative listener, based on the value of useOkButton[stepNum]) after delay. 
    //Since the pop up is created after a delay, this ensure it doesn't try to retrieve the button before it is created
    IEnumerator SetUpButton() {
        yield return new WaitForSeconds(delay);
        // If this step of the tutorial uses something other than the OK button to mark its completion, set up the appropriate listener.
        // Otherwise, use the default listener.
        switch (stepNum) {
            case 2: // Select GPU
                goalObjRenderer = gpuObj.GetComponentInChildren<Renderer>();
                checkForHighlight = true;
                break;
            case 3: // Close ComponentMenu
                menuCheckType = 3;
                checkForMenu = true;
                break;
            case 4: // Open ToC
                menuCheckType = 0;
                checkForMenu = true;
                break;
            case 5: // hide CPU Cooling
                checkToggle = true;
                break;
            case 6: // Close ToC
                menuCheckType = 1;
                checkForMenu = true;
                break;
            case 7: // Select Cooling Fan
                goalObjRenderer = caseCoolingObj.GetComponentInChildren<Renderer>();
                checkForHighlight = true;
                break;
            default: // OK Button
                Button popBtn = popUpMgr.getPopUpButton();
                popBtn.onClick.AddListener(delegate {
                    NextPopUp();
                });
                break;
        }
    }
}
