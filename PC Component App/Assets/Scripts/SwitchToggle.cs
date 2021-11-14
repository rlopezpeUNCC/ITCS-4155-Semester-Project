using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;

    Color backgroundDefaultColor, handleDefaultColor;

    Image backgroundImage, handleImage;

    Toggle tog;
    Vector2 handlePosition;

    void Awake() {
        tog = GetComponent <Toggle> ();
        handlePosition = uiHandleRectTransform.anchoredPosition;
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;
        tog.onValueChanged.AddListener(OnSwitch);

        if(tog.isOn)
            OnSwitch(true);
    }

    void OnSwitch(bool on) {
        uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition; 
        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
        handleImage.color = on ? handleActiveColor : handleDefaultColor;
    }

    void OnDestroy() {
        tog.onValueChanged.RemoveListener(OnSwitch);
    }
}
