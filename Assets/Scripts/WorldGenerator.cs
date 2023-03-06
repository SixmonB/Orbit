using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    private GameObject sphere_instance;
    private GameObject cube_instance;
    public GameObject orbit_object;
    public GameObject central_object;
    public float orbitRadius;
    public float orbitSpeed;
    private Vector3 orbitAxis;
    // Start is called before the first frame update
    void Start()
    {
        orbitSpeed = 50.0f;
        orbitRadius = 2.0f;
        cube_instance = Instantiate(central_object);
        sphere_instance = Instantiate(orbit_object);
        sphere_instance.transform.position = new Vector3(orbitRadius, 0.0f, orbitRadius);
        cube_instance.transform.position = new Vector3(0f, 0f, 0f);
        orbitAxis = new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        sphere_instance.transform.RotateAround(cube_instance.transform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}