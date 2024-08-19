using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waffen : MonoBehaviour
{
    public ParticleSystem ps;
    public bool started;
    public AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
     //   started = false;
     //   ps = GameObject.FindGameObjectWithTag("start").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // ps.Play();
       // started = true;
      // src.gameObject.SetActive(true);
    }
}
