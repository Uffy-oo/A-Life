using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taskPanel;

    public Activity currentActivity;

    private Activity act;

    private Student student;

    public Text taskDescriptionText; // 用于显示活动描述的文本组件

    public Image taskImage; // 用于显示活动图片的图片组件



    void Start()
    {
        taskPanel.SetActive(false);
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
        if (currentActivity != null)
        {
            taskDescriptionText.text = currentActivity.description;
            taskImage.sprite = currentActivity.image;
            taskPanel.SetActive(true);
        }
    }


    public void HideTask()
    {
        taskPanel.SetActive(false);
    }

    public void CheckActivity() {
            switch (act.aActivity) { // comparing activity types
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
