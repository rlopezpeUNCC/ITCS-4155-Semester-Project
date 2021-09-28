using UnityEngine;
//currently attached to Main Camera
public class ObjectClicker : MonoBehaviour {

    void Update() {
        //checks if m1 is pressed
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            //sends out a raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //stores any object hit by the ray into 'hit', and sets the distance the ray will travel to 100
            if (Physics.Raycast(ray, out hit, 100f)) {
                //makes sure a object is hit, and not NULL
                if (hit.transform) {
                    PrintName(hit.transform.gameObject);
                }
            }
        }
    }
    //prints the name of an object in the console
    void PrintName(GameObject go) {
        print(go.name);
    }
}
