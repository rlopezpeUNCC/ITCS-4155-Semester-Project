using UnityEngine;
using TMPro;

public class bringUpMenu : MonoBehaviour {
    [SerializeField]
    GameObject menu;
    [SerializeField]
    TextMeshProUGUI text;

    public void ShowMenu() { 
        if (menu.active) {
            menu.SetActive(false);
        } else {
            menu.SetActive(true);
        }        
    }

    public void HideMenu() {
        text.enabled = false;
    }

}
