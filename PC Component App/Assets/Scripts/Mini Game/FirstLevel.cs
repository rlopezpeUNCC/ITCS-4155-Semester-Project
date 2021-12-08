using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
// CUrrently attached to Motherboard in Mini Game

public class FirstLevel : MonoBehaviour
{
    public GameObject motherboard, cpu, cpuFan, ram, gpu, ramHandler, cpuHandler, cpuFanHandler, gpuHandler, introPanel, sidePanel, finished;
    public TextMeshProUGUI scoreField, description, endCardSub;
    private int score, correctNum;
    private bool noCPU;

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
        correctNum = 0;
        noCPU = true;
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
        if(correctNum >= 4)
        {
            cpu.SetActive(false);
            ram.SetActive(false);
            cpuFan.SetActive(false);
            gpu.SetActive(false);
            motherboard.SetActive(false);
            EndLevel();
        }
    }

    // Hides instructions so user can play game (not to be confused with the Start() method above!!!)
    public void StartLevel() {
        introPanel.SetActive(false);
        sidePanel.SetActive(true);
    }

    public void EndLevel()
    {
        endCardSub.SetText("SCORE: " + score.ToString());
        sidePanel.SetActive(false);
        finished.SetActive(true);
    }

    // Displays right/wrong choices for part placement
    public void ChangeButtons(string component)
    {
        if (component == "CPU" || component == "Chip")
        {
            description.SetText("Most CPU's have an arrow that shows the correct orientation of it");
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(false);
            gpuHandler.SetActive(false);
            cpuHandler.SetActive(true);

        }
        else if (component == "CPU Fan")
        {
            description.SetText("Please only put a small amount of thermal paste\n(pea size)");
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(false);
            cpuFanHandler.SetActive(true);
        }
        else if (component == "RAM")
        {
            description.SetText("Make sure to purchase RAM of the same brand and type. You will have issues otherwise.");
            cpuFanHandler.SetActive(false);
            cpuHandler.SetActive(false);
            gpuHandler.SetActive(false);
            ramHandler.SetActive(true);
        }
        else if (component == "GPU")
        {
            description.SetText("If you are lucky enough to get one at this time, be very careful with it!");
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
            FindObjectOfType<AudioManager>().Play("ButtonClicked1");         
            description.SetText("Correct!");
            // Hide choice buttons and place part
            string parentName = thisButton.transform.parent.name;
            if (parentName.Trim() == "CPU Button Canvas") {
                noCPU = false;
                score += 10;
                scoreField.SetText(score.ToString());
                correctNum += 1;
                cpuHandler.SetActive(false);
                cpu.transform.position = new Vector3(-1.21f, .07f, 6.275f);
            } else if (parentName.Trim() == "RAM Button Canvas") {
                score += 10;
                scoreField.SetText(score.ToString());
                correctNum += 1;
                ramHandler.SetActive(false);
                ram.transform.position = new Vector3(.82f, .08f, 7.37f);
            } else if (parentName.Trim() == "Fan Button Canvas") {
                if (noCPU)
                {
                    description.SetText("The CPU fan DOES go there, but there is nothing to cool yet!");
                }
                else
                {
                    score += 10;
                    scoreField.SetText(score.ToString());
                    correctNum += 1;
                    cpuFanHandler.SetActive(false);
                    cpuFan.transform.position = new Vector3(-1.12f, 2.13f, 5.4f);
                }
            } else if (parentName.Trim() == "GPU Button Canvas") {
                score += 10;
                scoreField.SetText(score.ToString());
                correctNum += 1;
                gpuHandler.SetActive(false);
                gpu.transform.position = new Vector3(-0.3f, -.04f, 5.2f);
            }
        } else { // wrong choice made
            FindObjectOfType<AudioManager>().Play("Incorrect");
            score -= 5;
            if (score < -999) { score = -999 ;} // prevent errors
            scoreField.SetText(score.ToString());
        }
    }

    // Copy of BackToMainMenu from ComponentMenu (would need to import lots of unused things otherwise)
    public void BackToMainMenu(){
        FindObjectOfType<AudioManager>().Play("ToMainMenu");
        SceneManager.LoadScene("Main Menu");
    }
}

