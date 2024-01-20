using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taskPanel;

    public Activity currentActivity;

    private Activity act;

    private Student student;

    void Start()
    {
        taskPanel.SetActive(false);
        AssignNewActivity();
    }

    public void AssignNewActivity()
    {
        Activity activityManager = FindObjectOfType<T>();
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
                case Activity_class.Relax:
                    student.AfterRelax();
                    break;

                case Activity_class.Networking:
                    student.AfterNetworking();
                    break;

                case Activity_class.Study:
                    student.AfterStudy();
                    break;
    }
    }

}
