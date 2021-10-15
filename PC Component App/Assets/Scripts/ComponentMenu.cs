using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class ComponentMenu : MonoBehaviour
{
    [SerializeField]
   TextMeshProUGUI componentName,componentDescription,componentPrice;
    [SerializeField]
    GameObject menu;

    //one for each component
   componentDetail CPU = new componentDetail();
   componentDetail GraphicsCard = new componentDetail();
   componentDetail CPUCooler = new componentDetail();
   componentDetail RAM = new componentDetail();
   componentDetail Case = new componentDetail();
   componentDetail CaseCooling = new componentDetail();
   componentDetail Motherboard = new componentDetail();
   componentDetail PowerSupply = new componentDetail();
   


   public struct componentDetail
   {
    public string  name;
    public string  description;
    public string  price;
   } 
   
    // Start is called before the first frame update
    void Start()
    {
        
// all 3 one for each
        CPU.name = "name";
        CPU.description = "description";
        CPU.price = "price";

        GraphicsCard.name = "name";
        GraphicsCard.description = " A motherboard is the main printed circuit board in general-purpose computers and other expandable systems. "+
        "It holds and allows communication between many of the crucial electronic components of a system, such as the central processing unit and memory, and provides connectors for other peripherals";
        GraphicsCard.price = "price";

        CPUCooler.name = "name";
        CPUCooler.description = "description";
        CPUCooler.price = "price";

        RAM.name = "name";
        RAM.description = "description";
        RAM.price = "price";

        Case.name = "name";
        Case.description = "description";
        Case.price = "price";

        CaseCooling.name = "name";
        CaseCooling.description = "description";
        CaseCooling.price = "price";

        Motherboard.name = "name";
        Motherboard.description = "description";
        Motherboard.price = "price";

        PowerSupply.name = "name";
        PowerSupply.description = "description";
        PowerSupply.price = "price";


        DetailSetup("CPU");
        DetailSetup("GraphicsCard");
        DetailSetup("CPUCooler");
        DetailSetup("RAM");
        DetailSetup("Case");
        DetailSetup("CaseCooling");
        DetailSetup("Motherboard");
        DetailSetup("PowerSupply");

    }

    public void DetailSetup (string component) {
        menu.active = true;
        Debug.Log(component);
        
        switch (component){

            case ("CPU"):
                componentName.text = CPU.name;
                componentDescription.text = CPU.description;
                componentPrice.text = CPU.price;

                break;

            case ("Motherboard"):
                componentName.text = Motherboard.name;
                componentDescription.text = Motherboard.description;
                componentPrice.text = Motherboard.price;
                break;

            case ("GPU"):
                componentName.text = GraphicsCard.name;
                componentDescription.text = GraphicsCard.description;
                componentPrice.text = GraphicsCard.price;
                break;

            case ("CPUCooler"):
                componentName.text = CPUCooler.name;
                componentName.text = CPUCooler.description;
                componentName.text = CPUCooler.price;
                break;

            case ("RAM"):
                componentName.text = RAM.name;
                componentName.text = RAM.description;
                componentName.text = RAM.price;
                break;

            case ("Case"):
                componentName.text = Case.name;
                componentName.text = Case.description;
                componentName.text = Case.price;
                break;

            case ("CaseCooling"):
                componentName.text = CaseCooling.name;
                componentName.text = CaseCooling.description;
                componentName.text = CaseCooling.price;
                break;

             case ("PowerSupply"):
                componentName.text = PowerSupply.name;
                componentName.text = PowerSupply.description;
                componentName.text = PowerSupply.price;
                break;

        }

    }

    public void Close (){
            menu.active = false;
        }

}
