using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject cameraTarget;

    Vector3 cameraOffset;
    float startAngle = 0f;
    float rotateAngle;
    int keyPressed = 1;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-0.66f, 0.62f, -4.01f);
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
        }
        else if (Input.GetKey("3"))
        {
            keyPressed = 3;
            //transform.position = cameraTarget.transform.position;
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
            //rotateAngle = startAngle + 0.5f;
            //rotateAngle = Mathf.Lerp(rotateAngle, 0, 0.1f*Time.deltaTime);
            startAngle += 0.5f;
            Quaternion cameraRotation = Quaternion.Euler(0, startAngle, 0);
            transform.position = cameraTarget.transform.position - (cameraRotation * cameraOffset);
            transform.LookAt(cameraTarget.transform);
            
        }
        else if (keyPressed == 3)
        {

            float desiredAngle = cameraTarget.transform.eulerAngles.y;
            Quaternion cameraRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = cameraTarget.transform.rotation;
            //transform.position = Vector3.zero;
            transform.position = new Vector3 (cameraTarget.transform.position.x, 0.1f, cameraTarget.transform.position.z) ;
            //transform.position = transform.position - (cameraRotation * new Vector3 (0.001f,0.001f,0.001f));
            //transform.LookAt(cameraTarget.transform);

        }
        
        /**/
    }
}
