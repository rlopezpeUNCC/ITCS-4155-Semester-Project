using UnityEngine;
using UnityEngine.UI;
using System.Collections;
// Currently attached to AppManager

public class TutorialPopupManager : MonoBehaviour {
    [SerializeField]
    GameObject popUpPrefab;
    GameObject popUp;
    //delay between closing and creating new pop up
    float delay = 1.5f;
    
    //Creates the pop up at (positionX, positionY) with title and body
    public void CreatePopup(string title, string body, float positionX, float positionY, bool buttonEnabled) {
        //if popUp exist, close it
        if (popUp != null) {
            popUp.GetComponent<tutorialPopup>().Close();
        }
        //create new pop up after delay
        StartCoroutine(Create(title, body, positionX, positionY, buttonEnabled));
    }

    // Allows TutorialSteps to get popup button to make a listener with
    public Button getPopUpButton() {
        return popUp.GetComponent<tutorialPopup>().GetComponentInChildren<Button>();
    }

    public void Close() {
        popUp.GetComponent<tutorialPopup>().Close();
    }

    //creates popup clone from prefab after a delay
    IEnumerator Create(string title, string body, float x, float y, bool buttonEnabled) {
        yield return new WaitForSeconds(delay);
        popUp = Instantiate(popUpPrefab, Vector3.zero, Quaternion.identity);
        //sets up pop up
        popUp.GetComponent<tutorialPopup>().SetUp(title, body, buttonEnabled, x, y);
    }

    //returns delay
    public float GetDelay() {
        return delay;
    }

}
