using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordRb : MonoBehaviour
{
    public ParticleSystem ps;
    public AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // player = GameObject.FindGameObjectWithTag("Finish");
        //transform.position = transform.parent.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  StartCoroutine(showParticle());
        ps.Play();
        src.Play();
    }

    IEnumerator showParticle()
    {
        ps.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        ps.gameObject.SetActive(false);

    }

}

