using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CloseInfoUI();
    }

    public void CloseInfoUI()
    {
        // press ESC to exit game info
        if (Input.GetKey(KeyCode.Escape))
        {
            GameObject menu = GameObject.FindGameObjectWithTag("menuTest").transform.gameObject;
            GameObject GameInfoUI = GameObject.FindGameObjectWithTag("gameInfoUI").transform.gameObject;
            menu.transform.GetChild(0).gameObject.SetActive(true);
            GameInfoUI.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
