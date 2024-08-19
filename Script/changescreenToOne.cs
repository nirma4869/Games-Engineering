using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescreenToOne : MonoBehaviour
{
   // public Animator sceneAnim;
    // Start is called before the first frame update
    void Start()
    {
      //  sceneAnim = GameObject.FindGameObjectWithTag("screen").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // sceneAnim.Play("TransEnde");
        // StartCoroutine(LoadLevel());
        SceneManager.LoadScene("Scene1");


    }
    IEnumerator LoadLevel()
    {
      //  sceneAnim.Play("TransEnde");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scene1");
      //  sceneAnim.Play("ScreenTrans");

    }
}
