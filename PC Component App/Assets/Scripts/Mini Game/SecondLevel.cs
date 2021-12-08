using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SecondLevel : MonoBehaviour
{
    public GameObject oldSidePanel, pcCase, motherboard, caseFan, power, discDrives, storage, caseFanButtons, motherboardButtons, powerButtons, discDriveButtons, storageButtons, oldPanel, sidePanel, finished;
    public TextMeshProUGUI scoreField, desc, endCardSub;
    int correctNum, score;
    // Start is called before the first frame update
    void Start()
    {
        oldPanel.SetActive(false);
        oldSidePanel.SetActive(false);
        sidePanel.SetActive(true);
        pcCase.SetActive(true);
        caseFanButtons.SetActive(false);
        motherboardButtons.SetActive(false);
        powerButtons.SetActive(false);
        discDriveButtons.SetActive(false);
        storageButtons.SetActive(false);
        score = 0;
        correctNum = 0;
        MoveParts();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform)
                {
                    ShowButtons(hit.collider.transform.gameObject.name);
                }
            }
        }
        if (correctNum >= 5)
        {
            EndLevel();
        }
    }

    // Place parts at starting positions when level begins
    public void MoveParts()
    {
        pcCase.transform.position = new Vector3(-.3f, -.7f, 9f);
        motherboard.transform.position = new Vector3(11.6f, 14.7f, -18.5f);
        caseFan.transform.position = new Vector3(-3.5f, 9.87f, 5.1f);
        power.transform.position = new Vector3(3.7f, 9.4f, 9.1f);
        discDrives.transform.position = new Vector3(-2.5f, 6.6f, 9f);
        storage.transform.position = new Vector3(4.7f, 5.9f, 5.72f);
    }

    // Display placement options for currently selected part
    public void ShowButtons(string component)
    {
        if(component == "CMB")
        {
            desc.SetText("The motherboard will be fairly heavy at this point, be cautious");
            caseFanButtons.SetActive(false);
            motherboardButtons.SetActive(true);
            powerButtons.SetActive(false);
            discDriveButtons.SetActive(false);
            storageButtons.SetActive(false);
        }
        else if(component == "Case Cooling")
        {
            desc.SetText("This will differ depending on the case you have, but most will have a fan in this area.");
            caseFanButtons.SetActive(true);
            motherboardButtons.SetActive(false);
            powerButtons.SetActive(false);
            discDriveButtons.SetActive(false);
            storageButtons.SetActive(false);
        }
        else if(component == "Disc Drives")
        {
            desc.SetText("Most people building PC's won't use these but in case you do, this is where they go");
            caseFanButtons.SetActive(false);
            motherboardButtons.SetActive(false);
            powerButtons.SetActive(false);
            discDriveButtons.SetActive(true);
            storageButtons.SetActive(false);
        }
        else if(component == "Power Supply")
        {
            desc.SetText("This part comes with a lot of the cables you will need to connect things together");
            caseFanButtons.SetActive(false);
            motherboardButtons.SetActive(false);
            powerButtons.SetActive(true);
            discDriveButtons.SetActive(false);
            storageButtons.SetActive(false);
        }
        else if(component == "Storage")
        {
            desc.SetText("You can choose between SSD(better) or HDD(cheaper)");
            caseFanButtons.SetActive(false);
            motherboardButtons.SetActive(false);
            powerButtons.SetActive(false);
            discDriveButtons.SetActive(false);
            storageButtons.SetActive(true);
        }
    }

    // carry out game logic based on correctness and part choice
    public void ButtonClicked(Button thisButton)
    {
        if(thisButton.name == "Correct") { // Correct choice
            score += 10;
            scoreField.SetText(score.ToString());
            correctNum += 1;
            desc.SetText("Correct!");
            string parentName = thisButton.transform.parent.name;
            if(parentName.Trim() == "Complete Motherboard Button Canvas")
            {
                motherboardButtons.SetActive(false);
                motherboard.transform.position = new Vector3(2.5f, 14.1f, -17.5f);
            }
            else if(parentName.Trim() == "Case Cooling Button Canvas")
            {
                caseFanButtons.SetActive(false);
                caseFan.transform.position = new Vector3(2.5f, 0f, 5f);
                caseFan.transform.Rotate(0f, 0f, 90f);
            }
            else if(parentName.Trim() == "Disc Drives Button Canvas")
            {
                discDriveButtons.SetActive(false);
                discDrives.transform.position = new Vector3(2.5f, 1.5f, 8f);
            }
            else if(parentName.Trim() == "Power Button Canvas")
            {
                powerButtons.SetActive(false);
                power.transform.position = new Vector3(-.2f, -.7f, 9f);
            }
            else if(parentName.Trim() == "Storage Button Canvas")
            {
                storageButtons.SetActive(false);
                storage.transform.position = new Vector3(2.5f, -1.1f, 8f);
            }
        } else { // incorrect choice
            score -= 5;
            scoreField.SetText(score.ToString());
        }
    }

    public void StartLevel()
    {
        Start();
    }

    public void EndLevel() {
        endCardSub.SetText("SCORE: " + score.ToString());
        sidePanel.SetActive(false);
        finished.SetActive(true);
    }
}
