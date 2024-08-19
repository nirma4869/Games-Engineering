using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic musicInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
