using System.Collections;
using UnityEngine;	

public class rotateObject : MonoBehaviour{
	float speed = 150;
	
	void OnMouseDrag() {
		float rotX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

		transform.Rotate(Vector3.right, rotY, Space.World);
		transform.Rotate(Vector3.down, rotX, Space.World);
	}
}