using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

    public GameObject TargetParticles;

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            TargetParticles.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = collision.gameObject.GetComponent<MeshRenderer>().material;
            Instantiate(TargetParticles, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
