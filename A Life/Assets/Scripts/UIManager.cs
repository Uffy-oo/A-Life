using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UImanageer instance { get; private set; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
    
    public Image StaminaBar;
    public Image GradeScaleBar;

    public void UpdateStaminaBar (int curAmount, int maxAmount)
    {
        StaminaBar.fillAmount = (float) curAmount / (float) maxAmount;
    }

    public void UpdateGradeBar (int curAmount, int maxAmount)
    {
        GradeScaleBar.fillAmount = (float) curAmount / (float) maxAmount;
    }
}
