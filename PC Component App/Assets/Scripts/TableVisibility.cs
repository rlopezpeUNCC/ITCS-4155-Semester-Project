using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
// Currently attached to Canvas

public class TableVisibility : MonoBehaviour
{
    [SerializeField]
    GameObject ToCPanel;
    [SerializeField]
    Button ToCShowHide;

    // Start is called before the first frame update
    void Start()
    {
        ToCShowHide.onClick.AddListener(delegate {
            ButtonClicked(ToCShowHide);
        });
        print("Listener added for button " + ToCShowHide.name);
    }

    // On click, show/hide the ToC
    void ButtonClicked(Button btn)
    {
        print("Toggle clicked");
        ToCPanel.SetActive(!ToCPanel.activeSelf);
    }
}
