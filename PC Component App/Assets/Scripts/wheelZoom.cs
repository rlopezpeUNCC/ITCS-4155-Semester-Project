using UnityEngine;	

public class wheelZoom : MonoBehaviour{

	float max = 10.0F;
	float min = 1.0F;
	float speed;
	Camera mainCamera;
	
	private void Start(){
		speed = Time.deltaTime * 10.0F;
		mainCamera = Camera.main;
	}	

	private void Update(){	
		if (mainCamera.orthographic){
			if ((Input.GetAxis("Mouse ScrollWheel") > 0) & (mainCamera.orthographicSize > min)){
				Debug.Log("zooming");
				mainCamera.orthographicSize -= speed;
			}
			else if ((Input.GetAxis("Mouse ScrollWheel") < 0) & (mainCamera.orthographicSize < max)){
				mainCamera.orthographicSize += speed;
			}
			else{
				mainCamera.orthographicSize += 0.0F;
			}
		}
	}
}