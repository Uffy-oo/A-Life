using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject restPanel;
    public GameObject studyPanel;
    public GameObject networkingPanel;

    public Activity currentActivity;

    private Student student;

    public Text taskDescriptionText; // 用于显示活动描述的文本组件

    public Image taskImage; // 用于显示活动图片的图片组件



    void Start()
    {
        HideAllPanels();
        AssignNewActivity();
    }

    public void AssignNewActivity()
    {
        // Correcting the type from Activity to ActivitiesManager
        ActivitiesManager activityManager = FindObjectOfType<ActivitiesManager>();
        if (activityManager != null)
        {
            currentActivity = activityManager.GetRandomActivityForBuilding();
        }
        else
        {
            Debug.LogWarning("Activities Manager not found!");
        }
    }
    public void DisplayTask()
    {
        // 先隐藏所有 Panel

        // 根据当前活动类型显示相应的 Panel
        switch (currentActivity.aActivity)
        {
            case Activity_class.Relax:
                restPanel.SetActive(true);
                break;
            case Activity_class.Study:
                studyPanel.SetActive(true);
                break;
            case Activity_class.Networking:
                networkingPanel.SetActive(true);
                break;
        }

        // 更新 Panel 上的文本和图片信息
        taskDescriptionText.text = currentActivity.description;
        taskImage.sprite = currentActivity.image;
    }

    public void HideAllPanels()
    {
        restPanel.SetActive(false);
        studyPanel.SetActive(false);
        networkingPanel.SetActive(false);
    }


    public void CheckActivity()
    {
        switch (currentActivity.aActivity) // comparing activity types
        {
            case Activity_class.Relax:
                student.AfterRelax();
                break;
            case Activity_class.Networking:
                student.AfterNetworking(10);
                break;
            case Activity_class.Study:
                student.AfterStudy(10);
                break;
        }
    }
}


