using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject cameraTarget;
    public GameObject floor;

    Vector3 cameraOffset;
    float startAngle = 0f;
    float rotateAngle;
    int keyPressed = 1;
    float xCamera = -0.66f, yCamera = 0.62f, zCamera = -4.01f;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(xCamera, yCamera, zCamera);
        cameraOffset = cameraTarget.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetKey("1"))
        {
            keyPressed = 1;
            transform.position = cameraTarget.transform.position - cameraOffset;
            cameraOffset = cameraTarget.transform.position - transform.position;
        }
        else if (Input.GetKey("2"))
        {
            keyPressed = 2;
            startAngle = 0f;
            transform.position = cameraTarget.transform.position - cameraOffset;
            cameraOffset = cameraTarget.transform.position - transform.position;
        }
        else if (Input.GetKey("3"))
        {
            keyPressed = 3;
            //transform.position = cameraTarget.transform.position;
        }

        if (Input.GetKeyDown("7") && keyPressed != 3)
        {
            yCamera = cameraOffset.y + 0.1f;
            cameraOffset = new Vector3(cameraOffset.x, yCamera, cameraOffset.z);
        }
        else if (Input.GetKeyDown("8") && keyPressed != 3)
        {
            yCamera = cameraOffset.y - 0.1f;
            cameraOffset = new Vector3(cameraOffset.x, yCamera, cameraOffset.z);
        }

        if (Input.GetKeyDown("9") && keyPressed != 3)
        {
            zCamera = cameraOffset.z + 0.1f;
            cameraOffset = new Vector3(cameraOffset.x, cameraOffset.y, zCamera);

        }
        else if (Input.GetKeyDown("0") && keyPressed != 3)
        {
            zCamera = cameraOffset.z - 0.1f;
            cameraOffset = new Vector3(cameraOffset.x, cameraOffset.y, zCamera);
        }


        if (keyPressed == 1)
        {
            float desiredAngle = cameraTarget.transform.eulerAngles.y;
            Quaternion cameraRotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = cameraTarget.transform.position - (cameraRotation * cameraOffset);
            transform.LookAt(cameraTarget.transform);
        }
        else if (keyPressed == 2)
        {
            startAngle += 0.5f;
            Quaternion cameraRotation = Quaternion.Euler(0, startAngle, 0);
            transform.position = cameraTarget.transform.position - (cameraRotation * cameraOffset);
            transform.LookAt(cameraTarget.transform);
            
        }
        else if (keyPressed == 3)
        {
            transform.rotation = cameraTarget.transform.rotation;
            transform.position = new Vector3 (cameraTarget.transform.position.x, 0.1f, cameraTarget.transform.position.z) ;
        }
        
        /**/
    }
}
