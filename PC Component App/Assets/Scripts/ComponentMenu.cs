using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class ComponentMenu : MonoBehaviour
{
    [SerializeField]
   TextMeshProUGUI componentName,componentDescription,componentPrice;
    [SerializeField]
    GameObject menu;

   componentDetail CPU = new componentDetail();
   //moyher


   public struct componentDetail
   {
    public string  name;
    public string  description;
    public string  price;
   } 
   
    // Start is called before the first frame update
    void Start()
    {
        

        CPU.name = "name";
        CPU.description = "description";
        CPU.price = "price";

//mother

        DetailSetup("CPU");



    }

    public void DetailSetup (string component) {
        menu.active = true;

        switch (component){

            case ("CPU"):
                componentName.text = CPU.name;
                //des
                //price

                break;

            case ("motherboard"):
                //componentName.text = motherboard.name;
                break;







        }

        


    }

    public void Close (){
            menu.active = false;
        }

}
