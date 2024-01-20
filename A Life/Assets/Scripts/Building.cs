using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    private Text activityDescription;
    public gameObject taskPanel;

    private string currentActivity;

    private Activity a;

    void Start()
    {
        taskPanel.SetActive(false);
        AssignActivity();
    }

    public void AssignActivity()
    {
        Activities activitiesManager = FindObjectOfType<Activities>();
        if (activitiesManager != null)
        {
            currentActivity = activitiesManager.GetRandomActivity();
        }
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

    public bool checkType()
    {
        return currentActivity != null && currentActivity.type == type;
    }

}
