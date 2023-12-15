using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public GameObject redCube;
    public GameObject yellowCube;
    public GameObject blackCube;
    public GameObject blueCube;
    public GameObject purpleCube;

    public Camera mainCamera;
    public Color backgroundColorChange;

    private float ClickTimer = 0;
    private float ClickThreshold = 0.3f;
    public int clickNum = 0;

    public float raycastDistance = 20f;
    int gazeTimer = 0;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 4f, Screen.height / 2f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        RaycastHit hit;

        // Check if the ray hits an object within the specified distance
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Check if the hit object is the object you are interested in
            if (hit.collider.gameObject == redCube)
            {
                // The object is being looked at
                Debug.Log("You teleported to the red cube!");
                Teleport(redCube);
            }

            if (hit.collider.gameObject == purpleCube)
            {
                // The object is being looked at
                gazeTimer++;
                if (gazeTimer == 50)
                {
                    Debug.Log("You teleported to the purple cube!");
                    Teleport(purpleCube);
                    gazeTimer = 0;
                }
            }

            if (hit.collider.gameObject == blackCube)
            {
                if(clickNum == 1)
                {
                    Teleport(blackCube);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            ClickTimer = 0;
        }

        ClickTimer += Time.deltaTime;

        if (Input.GetMouseButtonUp(0))
        {
            clickNum += 1;
        }

        if (ClickTimer > ClickThreshold && clickNum > 0)
        {
            CardboardButtonPress();
            clickNum = 0;
        }
    }

    void CardboardButtonPress()
    {
        if (clickNum == 2)
        {
            RandomTeleport();
        }
        else if (clickNum == 3)
        {
            Debug.Log("You clicked thrice!");
            Teleport(blueCube);
        }
    }

    // teleport to a specific location
    void Teleport(GameObject targetLocation)
    {
        transform.position = targetLocation.transform.position;
    }

    void RandomTeleport()
    {
        int randomNumber = Random.Range(1, 6);
        Debug.Log("Random Number: " + randomNumber);
        if (randomNumber == 1)
        {
            Teleport(redCube);
        }
        else if (randomNumber == 2)
        {
            Teleport(yellowCube);
        }
        else if (randomNumber == 3)
        {
            Teleport(blackCube);
        }
        else if (randomNumber == 4)
        {
            Teleport(blueCube);
        }
        else if (randomNumber == 5)
        {
            Teleport(purpleCube);
        }
    }
}