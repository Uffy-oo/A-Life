using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student 
{
    public int GradeScale { get; set; }
    public int LinkedonConnection { get; set; }
    public int Stamina { get; set; }
    // Start is called before the first frame update

    public int getMaxStamina()
    {
        return this.Stamina;
    }

    public void setMaxStamina(int a)
    {
        this.Stamina = a;
    }

    // set a addmethod with restrictions

    public int addStamina(int value)
    {
        int answer = this.Stamina + value;
        if (answer < 100)
        {
            return answer;
        }
        else
        {
            return 100;
        }

    }
    public int minusStamina(int value)
    {
        int answer = this.Stamina - value;
        if (answer > 0)
        {
            return answer;
        }
        else
        {
            return 0;
        }
    }

    public int addConnection(int value)
    {
        int answer = this.LinkedonConnection + value;
        return answer;
    }

    public int addGrade(int value)
    {
        int answer = this.GradeScale + value;
        return answer;
    }
}
