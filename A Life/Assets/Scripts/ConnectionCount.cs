using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionCount : MonoBehaviour
{
    public Text ConnectionText;
    public GameManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        int value = manager.TotalConnection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCountDisplay()
    {
        ConnectionText.text = "Linkedon Connection: " + value.ToString();
    }
}
