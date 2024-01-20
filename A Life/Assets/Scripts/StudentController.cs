using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxStamina;

    Rigidbody2D rigidbody2d;

    float horizontal;
    float vertical;
    private Building nearbyBuilding = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // display task if building is nearby and 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E) && nearbyBuilding!= null) {
            nearbyBuilding.displayTask();
        }


        // hide task if 'X' is pressed
        if (Input.GetKeyDown(KeyCode.X) && nearbyBuilding!= null) {
            nearbyBuilding.HideTask();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            Building building = other.gameObject.GetComponent<Building>();
            if (building != null)
            {
                // Set nearbyBuilding if the student is close enough to the building
                nearbyBuilding = building;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building") && nearbyBuilding == other.gameObject.GetComponent<Building>())
        {
            // Clear nearbyBuilding if the student is no longer close to the building
            nearbyBuilding = null;
        }
    }

}
