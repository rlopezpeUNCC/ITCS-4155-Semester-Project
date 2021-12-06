using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SecondLevel : MonoBehaviour
{
    public GameObject oldSidePanel, pcCase, motherboard, caseFan, power, discDrives, storage, caseFanButtons, motherboardButtons, powerButtons, discDriveButtons, storageButtons, oldPanel, sidePanel;
    public TextMeshProUGUI scoreField;
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

        }
    }
    public void MoveParts()
    {
        pcCase.transform.position = new Vector3(-.3f, -.7f, 9f);
        motherboard.transform.position = new Vector3(11.6f, 14.7f, -18.5f);
        caseFan.transform.position = new Vector3(-3.5f, 9.87f, 5.1f);
        power.transform.position = new Vector3(.47f, 9.4f, 9.1f);
        discDrives.transform.position = new Vector3(-2.5f, 6.6f, 9f);
        storage.transform.position = new Vector3(4.7f, 5.9f, 5.72f);
    }
    public void ShowButtons(string component)
    {

    }

    public void Buttonclicked(Button thisButton)
    {
        if(thisButton.name == "Correct")
        {
            correctNum += 1;
            string parentName = thisButton.transform.parent.name;
            if(parentName.Trim() == "Complete Motherboard Button Canvas")
            {
                motherboardButtons.SetActive(false);
            }
            else if(parentName.Trim() == "Case Cooling Button Canvas")
            {
                caseFanButtons.SetActive(false);
            }
        }
    }

    public void StartLevel()
    {
        Start();
    }
}
