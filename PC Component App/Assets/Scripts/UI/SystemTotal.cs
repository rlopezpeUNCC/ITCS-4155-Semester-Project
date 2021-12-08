using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemTotal : MonoBehaviour
{
    float price = 0;
    public Text totalPrice;
    //DropDown system = totalPrice.GetComponent<DropDown>();
    public DropDown system;

    // Update is called once per frame
    void Update()
    {
     	if (price != system.GetPrice())
	{  
        	    price = system.GetPrice();
	    totalPrice.text = "System Total: $" + price.ToString();
	}
        	
    }
}