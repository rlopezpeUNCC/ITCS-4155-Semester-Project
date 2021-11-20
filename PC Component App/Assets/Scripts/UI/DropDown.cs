using UnityEngine; 
using System.Collections.Generic;
using System.Data;
//using Mono.Data.Sqlite;
using System.IO;

public class DropDown : MonoBehaviour {
    [SerializeField]
    TMPro.TMP_Dropdown dropdown;
    [SerializeField]
    ComponentMenu componentMenu;
    string selectedComponent = "Default";

    void Start() {/*
        string connection = "URI=file:" + Application.dataPath + "/Scraper_Files/Databases/Cases.db";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query ="SELECT * FROM Cases";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read()){
            Debug.Log("Name: " + reader[0].ToString());
            Debug.Log("Cost: " + reader[1].ToString());
        }
        dbcon.Close();
        */
    }

    void Update() {
        if (componentMenu.GetName() != selectedComponent) {
            selectedComponent = componentMenu.GetName();
            UpdateList();
        }
    }
    
    void UpdateList() {
        dropdown.ClearOptions();
        List<string> PCcase = new List<string> { "Case default"};
        switch(selectedComponent) {
            case("Case"):
                dropdown.AddOptions(PCcase);
                break;
            default:

                break;
        }
    }
   
}
