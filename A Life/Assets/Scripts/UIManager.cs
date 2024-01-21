using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public Image StaminaBar;
    public Image GradeScaleBar;

 

    void Start()
    {
        instance = this;
    }
    

    public void UpdateStaminaBar (int curAmount, int maxAmount)
    {
        StaminaBar.fillAmount = (float) curAmount / (float) maxAmount;
    }

    public void UpdateGradeBar (int curAmount, int maxAmount)
    {
        GradeScaleBar.fillAmount = (float) curAmount / (float) maxAmount;
    }
}
