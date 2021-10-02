using UnityEngine;	

public class wheelZoom : MonoBehaviour{

	float max = 10.0F;
	float min = 1.0F;
	float speed = Time.deltaTime * 10.0F;
	Camera camera;
	
	private void Start(){
		camera = Camera.main;
	}	

	private void Update(){	
		if (camera.orthographic){
			if ((Input.GetAxis("Mouse ScrollWheel") > 0) & (camera.orthographicSize > min)){
				camera.orthographicSize -= speed;
			}
			else if ((Input.GetAxis("Mouse ScrollWheel") < 0) & (camera.orthographicSize < max)){
				camera.orthographicSize += speed;
			}
			else{
				camera.orthographicSize += 0.0F;
			}
		}
	}
}