using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject Cube;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cast a ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 4f, Screen.height / 2f, 0f));
        RaycastHit hit;

        // Check if the ray hits this object
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            // The object is being looked at, rotate and change its color
            RotateObject();
        }
    }

    void RotateObject()
    {
        // Rotate the object based on the rotationSpeed
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}