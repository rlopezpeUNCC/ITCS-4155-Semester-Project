using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Currently attached to AppManager

public class TutorialPopupManager : MonoBehaviour {
    [SerializeField]
    GameObject popUpPrefab;
    GameObject popUp;
    void Start() {
        //CreatePopup("Test", "Hello World", 0, 0, true);
    }

    //Creates the pop up at (positionX, positionY) with title and body
    public void CreatePopup(string title, string body, float positionX, float positionY, bool buttonEnabled) {
        if (popUp != null) {
            popUp.GetComponent<tutorialPopup>().Close();
        }
        popUp = Instantiate(popUpPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
        popUp.GetComponent<tutorialPopup>().SetUp(title, body, buttonEnabled);
    }

    // Allows TutorialSteps to get popup button to make a listener with
    public Button getPopUpButton() {
        return popUp.GetComponent<tutorialPopup>().GetComponentInChildren<Button>();
    }

    public void Close() {
        popUp.GetComponent<tutorialPopup>().Close();
    }
}
