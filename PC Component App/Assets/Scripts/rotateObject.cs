
using UnityEngine;	

public class rotateObject : MonoBehaviour{

	float rotX, rotY;
	float speed, scale;

	private void Start(){

		speed = 5;
		scale = 0.5f;
	}	
	
	private void OnMouseDrag(){

		rotX += Input.GetAxis("Mouse X") * speed;
		rotY += Input.GetAxis("Mouse Y") * speed;

		Quaternion target = Quaternion.Euler(rotY, -rotX, 0);

		transform.rotation = Quaternion.Slerp(transform.rotation, target, scale);
	}
}