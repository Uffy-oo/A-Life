using System.Collections.Generic;
using UnityEngine;

public class ActivitiesManager : MonoBehaviour
{
    public List<Activity> allActivities; // Populate in the Unity Editor
    private List<Activity> shuffledActivities;

    void Start()
    {
        InitializeActivitiesForRound();
    }

    public void InitializeActivitiesForRound()
    {
        // Ensure there's at least one activity of each type
        shuffledActivities = new List<Activity>(allActivities);

        // Shuffle the activities
        int n = shuffledActivities.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Activity activity = shuffledActivities[k];
            shuffledActivities[k] = shuffledActivities[n];
            shuffledActivities[n] = activity;
        }
    }

    public Activity GetRandomActivityForBuilding()
    {
        if (shuffledActivities.Count == 0)
        {
            Debug.LogWarning("No more activities to assign!");
            return null;
        }

        // Pop the first activity off the list
        Activity selectedActivity = shuffledActivities[0];
        shuffledActivities.RemoveAt(0);
        return selectedActivity;
    }
}