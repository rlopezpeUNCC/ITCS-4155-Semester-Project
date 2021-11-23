using UnityEngine; 
using System.Collections.Generic;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class DropDown : MonoBehaviour {
    
    [SerializeField]
    TMPro.TMP_Dropdown dropdown;
    [SerializeField]
    ComponentMenu componentMenu;
    string selectedComponent = "Default";

    void Update() {
        if (componentMenu.GetName() != selectedComponent) {
            selectedComponent = componentMenu.GetName();
            UpdateList();
        }
    }
    
    void UpdateList() {
        dropdown.ClearOptions();
        switch(selectedComponent) {
            case("Case"):
                ReadDataBase("Cases");                
                break;
            case("CPU"):
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
                ReadDataBase("SSDs");                
                break;
            case("Motherboard"):
                ReadDataBase("Boards");                
                break;
            case("Power Supply"):
                ReadDataBase("PowerSupply");                
                break;
            case("RAM"):
                ReadDataBase("Memory");                
                break;
            default:
                Debug.Log("Couldn't find: " + selectedComponent);
                break;
        }
    }

    void ReadDataBase(string component) {
        List<string> models =  new List<string>();
        List<string> URLs =  new List<string>();
        List<double> prices =  new List<double>();
        models.Add("Default");
        string conn = "URI=file:" + Application.dataPath + "/Database/"+component+".db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
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
   
}
