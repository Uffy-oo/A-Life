using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuTest : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// start game
    public void StartGame()
    {
        // Load scene, Load scene: menuTest
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
