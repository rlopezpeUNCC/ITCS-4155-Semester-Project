using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemTotal : MonoBehaviour
{
    float price = 0;
    public Text totalPrice;
    public DropDown systemPrice;

    void Start()
    {
        systemPrice.GetPrice();
    }

    void Update()
    {   
        price = systemPrice.GetPrice();
	    totalPrice.text = "System Total: $" + price.ToString("0.00");
    }
}