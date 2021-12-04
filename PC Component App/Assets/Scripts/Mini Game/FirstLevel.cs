using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstLevel : MonoBehaviour
{
    public GameObject cpu, cpuFan, ram, gpu, ramHandler, cpuHandler, cpuFanHandler, gpuHandler, introPanel, sidePanel;
    public TextMeshProUGUI scoreField;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        ramHandler.SetActive(false);
        cpuFanHandler.SetActive(false);
        cpuHandler.SetActive(false);
        gpuHandler.SetActive(false);
        introPanel.SetActive(true);
        sidePanel.SetActive(false);
        score = 0;
    }

    // Update is called once per frame, detects which part user wants to place
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
                    ChangeButtons(hit.collider.transform.gameObject.name);
                }
            }
        }
    }

    // Hides instructions so user can play game (not to be confused with the Start() method above!!!)
    public void StartLevel() {
        introPanel.SetActive(false);
        sidePanel.SetActive(true);
    }

    // Displays right/wrong choices for part placement
    public void ChangeButtons(string component)
    {
        if (component == "CPU")
        {
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(false);
            gpuHandler.SetActive(false);
            cpuHandler.SetActive(true);

        }
        else if (component == "CPU Fan")
        {
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(true);
        }
        else if (component == "RAM")
        {
            cpuFanHandler.SetActive(false);
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(true);
        }
        else if (component == "GPU")
        {
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(false);
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(true);
        }
    }

    // If correct placement is chosen, place the part there and add points; otherwise, they lose points
    public void ButtonClicked(Button thisButton)
    {
        if (thisButton.name == "Correct") { // Right choice made
            // Gain points
            score += 10;
            scoreField.SetText(score.ToString());

            // Hide choice buttons and place part
            string parentName = thisButton.transform.parent.name;
            if (parentName == "CPU Button Canvas") {
                cpuHandler.SetActive(false);
                cpu.transform.position = new Vector3(-1.21f, .07f, 6.275f);
            } else if (parentName == "RAM Button Canvas") {
                ramHandler.SetActive(false);
                ram.transform.position = new Vector3(.82f, .08f, 7.37f);
            } else if (parentName.Trim() == "Fan Button Canvas") {
                cpuFanHandler.SetActive(false);
                cpuFan.transform.position = new Vector3(-1.12f, 2.13f, 5.4f);
            } else if (parentName == "GPU Button Canvas") {
                gpuHandler.SetActive(false);
                gpu.transform.position = new Vector3(-0.3f, -.04f, 5.2f);
            }
        } else { // wrong choice made
            score -= 5;
            if (score < -999) { score = -999 ;} // prevent errors
            scoreField.SetText(score.ToString());
        }
    }
}

