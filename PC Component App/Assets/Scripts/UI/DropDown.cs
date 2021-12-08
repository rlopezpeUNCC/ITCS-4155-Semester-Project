using UnityEngine; 
using System.Collections.Generic;
using Mono.Data.Sqlite; 
using System.Data; 
using TMPro;
using System;
public class DropDown : MonoBehaviour {
    
    [SerializeField]
    TMPro.TMP_Dropdown dropdown;
    [SerializeField]
    ComponentMenu componentMenu;
    [SerializeField]
    CompatabilityChecker compatability;
    List<string> URLs =  new List<string>();
    string selectedComponent = "Default", comp, selectedURL;

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
                print("checking cpu");
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
                print("checking storage");
                compatability.CheckCompatability(selectedModels, 5);
                ReadDataBase("SSDs");                
                break;
            case("Motherboard"):
                print("checking motherboard");
                compatability.CheckCompatability(selectedModels, 6);
                ReadDataBase("Boards");                
                break;
            case("Power Supply"):
                ReadDataBase("PowerSupply");                
                break;
            case("RAM"):
                print("checking RAM");
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
        URLs = new List<string>();
        List<string> models =  new List<string>();        
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
            string URL = reader.GetString(reader.FieldCount-1);
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
        index = dropdown.value-1;
        if (index >= 0) {
            selectedURL = URLs[index];
        //Debug.Log("Index of url " + index + " <" +selectedURL + ">");
        } else {
            selectedURL = null;
        }
        
    }
    /// <summary>
    /// Returns total price of all selected components
    /// </summary>
    public float GetPrice() {
        try {
        float price = 0;
        for (int i = 0; i < 9; i++) {
            if (selectedModels[i, 1].IndexOf("$") > 0)
            price += float.Parse(selectedModels[i, 1].Substring(selectedModels[i, 1].IndexOf("$")+1));
        }
        //Debug.Log("System price = " + price);
        return price;
        } catch (NullReferenceException) {
            return 0;
        }
    }
    /// <summary>
    /// Returns string containing URL of currently selected component and model
    /// </summary>
    public void OpenURL() {
        if (selectedURL != null)
        Application.OpenURL(selectedURL);
    }


}
