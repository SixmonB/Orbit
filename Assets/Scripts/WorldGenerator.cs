using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldGenerator : MonoBehaviour, UnityEngine.EventSystems.IPointerClickHandler
{
    private GameObject sphere_instance;
    private GameObject cube_instance;
    public GameObject orbit_object;
    public GameObject central_object;
    public float orbitRadius;
    private MeshRenderer meshRenderer;
    public float orbitSpeed;
    private Vector3 orbitAxis;
    // Start is called before the first frame update
    void Start()
    {
        orbitSpeed = 100.0f;
        orbitRadius = 1.5f;
        cube_instance = Instantiate(central_object, transform);
        sphere_instance = Instantiate(orbit_object);
        sphere_instance.transform.position = new Vector3(orbitRadius, 0.0f, orbitRadius);
        cube_instance.transform.position = new Vector3(0f, 0f, 0f);
        orbitAxis = new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        sphere_instance.transform.RotateAround(cube_instance.transform.position, orbitAxis, orbitSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed!");
            orbitAxis *= -1;
            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        meshRenderer = sphere_instance.GetComponent<MeshRenderer>();
        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        
        meshRenderer = cube_instance.GetComponent<MeshRenderer>();
        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        // Do something when the cube instance is clicked
    }
}