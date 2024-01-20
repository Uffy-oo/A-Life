using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taskPanel;

    private Activity act;

    private Student student;

    void Start()
    {
        taskPanel.SetActive(false);
        AssignActivity();
    }

    public void AssignNewActivity()
    {
        Activity activityManager = FindObjectOfType<Activity>();
        if (activityManager != null)
        {
            currentActivity = activityManager.GetRandomActivityForBuilding();
        }
        else
        {
            Debug.LogWarning("Activities Manager not found!");//
        }

        // if (currentActivity != null)
        // {
        //     // If you have UI elements or other components that need to be updated, do it here.
        //     // For example:
        //     // activityDescription.text = currentActivity.description;
        // }
    }
    public void DisplayTask()
    {
        if (currentActivity != null)
        {
            // taskDescriptionText.text = currentActivity;
            taskPanel.SetActive(true);
        }
    }

    public void HideTask()
    {
        taskPanel.SetActive(false);
    }

    public void CheckActivity() {
            switch (act.aActivity) { // comparing activity types
                case Activity_Class.Relax:
                    student.AfterRelax();
                    break;

                case Activity_Class.Networking:
                    student.AfterNetworking();
                    break;

                case Activity_Class.Study:
                    student.AfterStudy();
                    break;
    }
    }

}
