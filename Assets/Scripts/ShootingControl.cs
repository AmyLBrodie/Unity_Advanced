using UnityEngine;
using System.Collections;

public class ShootingControl : MonoBehaviour {

    public GameObject bullet;

    private int speed = 30;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("e"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                newBullet.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * speed;
            }
        }
	}
}
