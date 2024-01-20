using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    private Activity_class aActivity;

    // Start is called before the first frame update
    public Activity(Activity_class pActivity)
    {
        this.aActivity = pActivity;
    }

    // Update is called once per frame
    public void Relaxmethod()
    {
        StudentController student1 = new StudentController();
        int studentStamina = student1.getMaxStamina();
        if (studentStamina < 80 && studentStamina > 0)
        {
            int b = student1.addStamina(20);
        }
    }
}