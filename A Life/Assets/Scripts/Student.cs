using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student 
{
    public float GradeScale { get; set; }
    public int LinkedonConnection { get; set; }
    public int Stamina { get; set; }
    public int WeeksLeft = 16;
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

    public float addGrade(int value)
    {
        float answer = this.GradeScale + value;
        return answer;
    }

    public void AfterRelax()
    {
        if (this.Stamina > 0 && WeeksLeft >= 1)
        {
            this.addStamina(20);
            ReduceWeek();
        }

    }

    public void AfterNetworking(int value)
    {
 
        if (Stamina >= 10 && WeeksLeft >= 1)
        {
            minusStamina(10 );
            addConnection(value);
            ReduceWeek();
        }
    }

    public void AfterStudy(int value)
    {

        if (Stamina >= 10 && WeeksLeft >= 1 )
        {
            minusStamina(10);
            addGrade(value);
            ReduceWeek();
        }
    }

    public void ReduceWeek()
    {
        this.WeeksLeft--;
    }
}
