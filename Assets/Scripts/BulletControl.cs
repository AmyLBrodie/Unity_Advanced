using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

    public GameObject TargetParticles;

    // checks for collisions
	void OnCollisionEnter(Collision collision)
    {
        // ensures collision is between bullet and target and then sets particle material and destroys the bullet and target
        if (collision.gameObject.tag == "Target")
        {
            TargetParticles.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = collision.gameObject.GetComponent<MeshRenderer>().material;
            Instantiate(TargetParticles, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        // checks if collision is between wall and bullet and destroys bullet
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
