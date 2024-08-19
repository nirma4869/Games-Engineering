using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public Animator sceneAnim;
    // Start is called before the first frame update
    void Start()
    {
        sceneAnim = GameObject.FindGameObjectWithTag("screen").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("Scene2");
        
    }
}
