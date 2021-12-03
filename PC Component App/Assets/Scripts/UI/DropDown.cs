using UnityEngine; 
using System.Collections.Generic;
using Mono.Data.Sqlite; 
using System.Data; 
using TMPro;
public class DropDown : MonoBehaviour {
    
    [SerializeField]
    TMPro.TMP_Dropdown dropdown;
    [SerializeField]
    ComponentMenu componentMenu;
    [SerializeField]
    CompatabilityChecker compatability;
    string selectedComponent = "Default", comp;

    string[,] selectedModels = new string[9, 2];
    void Start() {
        selectedModels[0, 0] = "Cases";
        selectedModels[1, 0] = "Processors";
        selectedModels[2, 0] = "CPUCoolin";
        selectedModels[3, 0] = "CaseCooling";
        selectedModels[4, 0] = "GPUs";
        selectedModels[5, 0] = "SSDs";
        selectedModels[6, 0] = "Boards";
        selectedModels[7, 0] = "PowerSupply";
        selectedModels[8, 0] = "Memory";

        for (int i = 0; i < 9; i++) {
            selectedModels[i, 1] = "Default";
        }
    }
    void Update() {
        if (componentMenu.GetName() != selectedComponent) {
            selectedComponent = componentMenu.GetName();
            UpdateList();
        }
    }
    public void UpdateList() {
        dropdown.ClearOptions();
        compatability.ClearIncompatablities();
        switch(selectedComponent) {
            case("Case"):
                ReadDataBase("Cases");                
                break;
            case("CPU"):
                compatability.CheckCompatability(selectedModels, 1);
                ReadDataBase("Processors");                
                break;
            case("CPU Cooling"):
                ReadDataBase("CPUCoolin");                
                break;
            case("Case Cooling"):
                ReadDataBase("CaseCooling");                
                break;
            case("GPU"):                
                ReadDataBase("GPUs");                
                break;
            case("Storage"):
                compatability.CheckCompatability(selectedModels, 5);
                ReadDataBase("SSDs");                
                break;
            case("Motherboard"):
                compatability.CheckCompatability(selectedModels, 6);
                ReadDataBase("Boards");                
                break;
            case("Power Supply"):
                ReadDataBase("PowerSupply");                
                break;
            case("RAM"):
                compatability.CheckCompatability(selectedModels, 8);
                ReadDataBase("Memory");                
                break;
            default:
                //Debug.Log("Couldn't find: " + selectedComponent);
                break;
        }
    }

    void ReadDataBase(string component) {
        comp = component;
        List<string> models =  new List<string>();
        List<string> URLs =  new List<string>();
        List<double> prices =  new List<double>();
        int index = 0;
        for (int i = 0; i < 9; i++) {
            if (component == selectedModels[i, 0]) {
                index = i;
                break;
            }            
        }
        if (selectedModels[index, 1] == "Default") {
            models.Add("Default");
        } else {
            //print("Setting list start to: " + selectedModels[index, 1]);
            models.Add(selectedModels[index, 1]);
            models.Add("Default");
        }
        string conn = "URI=file:" + Application.dataPath + "/Database/"+component+".db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        if (component == "CaseCooling") component = "Cooling";
        if (component == "CPUCoolin") component = "CPUCooling";
        string sqlQuery = "SELECT * FROM " +component;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            string model = reader.GetString(0) + " $" + reader.GetDouble(1).ToString();            
            string URL = reader.GetString(2);
            double price = reader.GetDouble(1);
            
            models.Add(model);
            URLs.Add(URL);
            prices.Add(price);
            //Debug.Log( "model= "+model+"  price =" +price+"  URL ="+  URL);
        }
        dropdown.AddOptions(models);
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void ItemSelected() {
      int index = 0;
      for (int i = 0; i < 9; i++) {
        if (comp == selectedModels[i, 0]) {
               //print("match found: " + comp + " " + selectedModels[i, 0]); 
               index = i;
               break;
           } 
        }
      selectedModels[index, 1] = dropdown.transform.Find("Label").GetComponent<TextMeshProUGUI>().text;
      compatability.CheckCompatability(selectedModels, index);
    }

    public float GetPrice() {
        float price = 0;
        for (int i = 0; i < 9; i++) {
            if (selectedModels[i, 1].IndexOf("$") > 0)
            price += float.Parse(selectedModels[i, 1].Substring(selectedModels[i, 1].IndexOf("$")+1));
        }
        //Debug.Log("System price = " + price);
        return price;
    }
}
