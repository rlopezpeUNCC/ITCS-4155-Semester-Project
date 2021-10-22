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
   componentDetail Storage = new componentDetail();
   componentDetail DiskDrivers = new componentDetail();

   


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
        CPU.name = "CPU";
        CPU.description = "A central processing unit, also called a central processor, main processor or just processor, is the electronic circuitry that executes instructions comprising a computer program. "+
        "The CPU performs basic arithmetic, logic, controlling, and input/output operations specified by the instructions in the program.";
        CPU.price = " $90 to $150";

        GraphicsCard.name = "GPU";
        GraphicsCard.description = " The graphics processing unit (GPU), also called a graphics card or video card is a specialized electronic circuit that accelerates the creation and rendering of images, video, and animations."+
        " It performs fast math calculations while freeing the CPU to perform other tasks.";
        GraphicsCard.price = "From $100  at the very low end to over $1,000 at the top end";

        CPUCooler.name = "CPU Cooling";
        CPUCooler.description = "A CPU cooler is a device designed to draw heat away from the system CPU and other components in the enclosure."+
        " Using a CPU cooler to lower CPU temperatures improves the efficiency and stability of the system. Adding a cooling device, however, can increase the overall noise level of the system.";
        CPUCooler.price = "Average cost $50";

        RAM.name = "RAM";
        RAM.description = "A RAM chip is a microchip used as RAM storage for computers and other devices. This is the actual chip that is soldered onto small circuit boards in order to create RAM cards or sticks, and it is rated for performance and capacity differently, depending on the model and manufacturer."+
        "RAM is available in different storage options.";
        RAM.price = "Between $100 and $200";

        Case.name = "Case";
        Case.description = "A computer case, also known as a computer chassis, tower, system unit, or cabinet, is the enclosure that contains most of the components of a personal computer"+
        " (usually excluding the display, keyboard, and mouse).";
        Case.price = "$100 to $150";

        CaseCooling.name = "Case Cooling";
        CaseCooling.description = "Case cooling’s job is to remove the hot air from the inside of your PC and help to replace it with cooler air from the outside."+
        " It is required to remove the waste heat produced by computer components, to keep components within permissible operating temperature limits. There are two types of cooling - liquid cooling and fan cooling.";
        CaseCooling.price = "Fan cooling can be around $50 whereas liquid cooling can cost around $150";

        Motherboard.name = "Motherboard";
        Motherboard.description = "A motherboard is the main printed circuit board in general-purpose computers and other expandable systems. It holds and allows communication between many of the crucial electronic components of a system, "+
        " such as the central processing unit and memory, and provides connectors for other peripherals.";
        Motherboard.price = "Can range anywhere from $100 to $500";

        PowerSupply.name = "Power Supply";
        PowerSupply.description = "Computer power supplies convert the alternate current from the power outlets in your home to the direct current your PC uses."+
        " They also provide power to the various components of the computer, such as hard drives, fans, and optical drives. ";
        PowerSupply.price = "Can range anywhere from $40 to $150";

        Storage.name = "Storage";
        Storage.description = "The purpose of a data storage component in the computer world is to store items (data) and allow easy access to them as shelves storage in the real world. "+
        "There are many different types of storage such as hard disk, CD ROM, RAM, floppy disks, etc.";
        Storage.price = "Depends on what type of storage you are looking for.";

        DiskDrivers.name = "DiskDrivers";
        DiskDrivers.description = "A disk drive is a device that allows a computer to read from and write data to a disk";
        DiskDrivers.price = "$100";


        DetailSetup("CPU");
        DetailSetup("GraphicsCard");
        DetailSetup("CPU Cooler");
        DetailSetup("RAM");
        DetailSetup("Case");
        DetailSetup("Case Cooling");
        DetailSetup("Motherboard");
        DetailSetup("Power Supply");
        DetailSetup("Storage");
        DetailSetup("DiskDrivers");
        

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

            case ("CPU Cooling"):
                componentName.text = CPUCooler.name;
                componentDescription.text = CPUCooler.description;
                componentPrice.text = CPUCooler.price;
                break;

            case ("RAM"):
                componentName.text = RAM.name;
                componentDescription.text = RAM.description;
                componentPrice.text = RAM.price;
                break;

            case ("Case"):
                componentName.text = Case.name;
                componentDescription.text = Case.description;
                componentPrice.text = Case.price;
                break;

            case ("Case Cooling"):
                componentName.text = CaseCooling.name;
                componentDescription.text = CaseCooling.description;
                componentPrice.text = CaseCooling.price;
                break;

             case ("Power Supply"):
                componentName.text = PowerSupply.name;
                componentDescription.text = PowerSupply.description;
                componentPrice.text = PowerSupply.price;
                break;

            case ("Storage"):
                componentName.text = Storage.name;
                componentDescription.text = Storage.description;
                componentPrice.text = Storage.price;
                break;

            case ("DiskDrivers"):
                componentName.text = DiskDrivers.name;
                componentDescription.text = DiskDrivers.description;
                componentPrice.text = DiskDrivers.price;
                break;


        }

    }

    public void Close (){
            menu.active = false;
        }

}
