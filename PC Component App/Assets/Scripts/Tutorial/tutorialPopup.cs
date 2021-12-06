using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class tutorialPopup : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI body, title;
    [SerializeField]
    GameObject ok, container;
    bool playCloseSound;

    void Start() {
        FindObjectOfType<AudioManager>().Play("Notification");
        gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    public void SetUp(string title, string body, bool buttonOn, float x, float y, bool playCloseSound) {
        this.body.text = body;
        this.title.text = title;
        Vector3 newPosition = new Vector3(x, y, 0);
        container.GetComponent<RectTransform>().anchoredPosition = newPosition;
        ok.SetActive(buttonOn);
        this.playCloseSound = playCloseSound;
        if (!playCloseSound) {
            this.title.fontSize = 28;
        }
    }

    public void Close() {
        if (playCloseSound) FindObjectOfType<AudioManager>().Play("Completed");
        Destroy(gameObject);
    }

}
