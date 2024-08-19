using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeRoom()
    {
        SceneManager.LoadScene("RoomScene");
    }
    public void changeStart()
    {
        SceneManager.LoadScene("StartScene");

    }
}
