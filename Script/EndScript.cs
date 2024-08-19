using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject player;
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        music = GameObject.FindGameObjectWithTag("Musik");
        Destroy(player);
        Destroy(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
