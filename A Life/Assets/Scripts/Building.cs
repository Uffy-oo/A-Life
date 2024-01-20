using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    private Text activityDescription;
    public GameObject taskPanel;

    private string currentActivity;

    private Activity act;

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
            taskDescriptionText.text = currentActivity;
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
                    act.AfterRelax();
                    break;

                case Activity_Class.Networking:
                    act.AfterNetworking();
                    break;

                case Activity_Class.Study:
                    act.AfterStudy();
                    break;
    }
    }

}
