using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity
{
    public Activity_class aActivity;

    // Start is called before the first frame update
    public Activity(Activity_class pActivity)
    {
        this.aActivity = pActivity;
    }

    // Update is called once per frame
    public void AfterRelax()
    {
        StudentController controller = new StudentController();
        Student student1 = controller.student;
        int studentStamina = student1.getMaxStamina();
        if (studentStamina > 0)
        {
           student1.addStamina(20);
        }

    }

    public void AfterNetworking(int value)
    {
        StudentController controller = new StudentController();
        Student student1 = controller.student;
        int studentStamina = student1.getMaxStamina();
        if (studentStamina >= 10)
        {
            student1.minusStamina(10);
            student1.addConnection(value);
        }
    }

    public void AfterStudy(int value)
    {
        StudentController controller = new StudentController();
        Student student1 = controller.student;
        int studentStamina = student1.getMaxStamina();
        if (studentStamina >= 10)
        {
            student1.minusStamina(10);
            student1.addGrade(value);
        }
    }


}