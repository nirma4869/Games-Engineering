using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragobFire : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    public Rigidbody2D rb;
    void Start()
    {
        StartCoroutine(kugel());
    }

    // Update is called once per frame
    void Update()
    {
        // Berechne die entgegengesetzte Richtung der Bewegung
        //   Vector2 movementDirection = rb.velocity.normalized;
        //  Vector2 emissionDirection = -movementDirection;

        // Setze die Emissionsrichtung des Partikelsystems
        //   var main = ps.main;
        //   main.startRotation = Mathf.Atan2(emissionDirection.y, emissionDirection.x);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            GameObject.Destroy(this.gameObject);
        }


    }
    IEnumerator kugel()
    {
        //  sceneAnim.Play("TransEnde");
        yield return new WaitForSeconds(5f);
        //SceneManager.LoadScene("Scene1");
        //  sceneAnim.Play("ScreenTrans");
        GameObject.Destroy(this.gameObject);
    }

}
