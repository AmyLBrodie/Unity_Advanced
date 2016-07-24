using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    private ParticleSystem particles;

	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        // checks if particle animation is finished and then destroys particle system
        if (particles.isStopped)
        {
            Destroy(gameObject);
        }
	}
}
