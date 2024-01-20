using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string activityText;
    private bool isPlayerInside;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPlayerInside)
        {
            dialogBoxText.text = activityText;
            dialogBox.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerInside = true;
    }

    void OnTriggerExit2D(Collider other)
    {
        isPlayerInside = false;
        dialogBox.SetActive(false);
    }
}
