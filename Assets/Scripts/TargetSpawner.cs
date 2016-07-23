using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

    public GameObject sphereTarget;
    public GameObject cubeTarget;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material mat5;
    public Material mat6;
    public Material mat7;
    public Material mat8;
    public Material mat9;

    private int numberOfSpheres;
    private int numberOfCubes;
    private Material[] materials = new Material[9];

	void OnEnable()
    {
        materials[0] = mat1;
        materials[1] = mat2;
        materials[2] = mat3;
        materials[3] = mat4;
        materials[4] = mat5;
        materials[5] = mat6;
        materials[6] = mat7;
        materials[7] = mat8;
        materials[8] = mat9;

        numberOfCubes = Random.Range(7,15);
        numberOfSpheres = Random.Range(7, 15);

        for (int i=0; i< numberOfCubes; i++)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Random.Range(-9.0f,9.0f),0.15f,Random.Range(-9.0f,9.0f));
            cubeTarget.GetComponent<MeshRenderer>().material = materials[Random.Range(0,9)];
            Instantiate(cubeTarget, spawnPosition, transform.rotation);
        }

        for (int i = 0; i < numberOfSpheres; i++)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Random.Range(-9.0f, 9.0f), 0.15f, Random.Range(-9.0f, 9.0f));
            sphereTarget.GetComponent<MeshRenderer>().material = materials[Random.Range(0,9)];
            Instantiate(sphereTarget, spawnPosition, transform.rotation);
        }
    }
}
