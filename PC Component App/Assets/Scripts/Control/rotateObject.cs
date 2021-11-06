using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// Currently attached to Computer

public class rotateObject : MonoBehaviour{
	float speed = 150;
	Vector3 defPos = new Vector3(0.0f, 0.0f, 14.39f);
	Quaternion defRot = new Quaternion(-0.5f, -0.5f, 0.5f, 0.5f);

	[SerializeField]
    Button ResetView;
	[SerializeField]
	Animator[] animations;

	// Start is called before the first frame update
    void Start()
    {
		FindObjectOfType<AudioManager>().Play("PCBuilding");
		// Add listener to ResetView
        ResetView.onClick.AddListener(delegate {
            ButtonClicked(ResetView);
        });
        //print("Listener added for button " + ResetView.name);
    }
	
	void OnMouseDrag() {
		float rotX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

		transform.Rotate(Vector3.right, rotY, Space.World);
		transform.Rotate(Vector3.down, rotX, Space.World);
	}

	// On click, reset Computer position
    void ButtonClicked(Button btn)
    {	
		transform.SetPositionAndRotation(defPos, defRot);
		foreach (Animator an in animations) {
			an.Play("Default", -1, 0f);
			an.speed = 1.75f;
		} 
		FindObjectOfType<AudioManager>().Play("PCBuildingFast");
        //print("ResetView clicked");
    }
}