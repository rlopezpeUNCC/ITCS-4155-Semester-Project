using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class tutorialPopup : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI body, title;
    [SerializeField]
    GameObject ok;

    void Start() {
        FindObjectOfType<AudioManager>().Play("Notification");
        gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    public void SetUp(string title, string body, bool buttonOn) {
        this.body.text = body;
        this.title.text = title;
        ok.SetActive(buttonOn);
    }

    public void Close() {
        FindObjectOfType<AudioManager>().Play("Completed");
        Destroy(gameObject);
    }

}
