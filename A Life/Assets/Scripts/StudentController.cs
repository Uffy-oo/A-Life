using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
    public float speed = 3.0f;


    Rigidbody2D rigidbody2d;

    int GradeScale;
    int LinkedonConnection;
    float horizontal;
    float vertical;
    private int maxStamina = 100;
    private Building nearbyBuilding = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        GradeScale = 0;
        LinkedonConnection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    public int getMaxStamina()
    {
        return this.maxStamina;
    }

    public void setMaxStamina(int a)
    {
        this.maxStamina = a;
    }

    // set a addmethod with restrictions

    public int addStamina(int value)
    {
        int answer = this.maxStamina + value;
        if (answer < 100)
        {
            return answer;
        }
        else
        {
            return 100;
        }

    // display task if building is nearby and 'E' is pressed
    if (Input.GetKeyDown(KeyCode.E) && nearbyBuilding!= null) {
        nearbyBuilding.displayTask();
    }


    // hide task if 'X' is pressed
    if (Input.GetKeyDown(KeyCode.X) && nearbyBuilding!= null) {
        nearbyBuilding.HideTask();
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

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
<<<<<<< Updated upstream
=======

    public int minusStamina(int value)
    {
        int answer = this.maxStamina - value;
        if (answer > 0)
        {
            return answer;
        }
        else
        {
            return 0;
        }
    }

    public int addConnection (int value)
    {
        int answer = this.LinkedonConnection + value;
        return answer;
    }

    public int addGrade(int value)
    {
        int answer = this.GradeScale + value;
        return answer;
    }
>>>>>>> Stashed changes
}