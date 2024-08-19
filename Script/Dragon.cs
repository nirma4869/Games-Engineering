using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Dragon : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    public GameObject dragon;
    public GameObject dragon2;
    public GameObject player;
    public float distanceBeforeTwo;
    private float timer;
    public bool canFire;
    public float timeBetweenFiring;
    public GameObject firePos;
    public GameObject fire;
    public float force;
    public bool schuss, schussFertig, kreis, kreuz, schwach, schwachLinks, schwachRechts;
    public int counter;
    public float distance;

    public bool inju;
    public AudioSource src1;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        dragon.SetActive(true);
        dragon2.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        if(counter > 4)
        {
            counter = 1;
        }
        if (schuss)
        {

            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;

                }

            }
            if (canFire)
            {
                GameObject shoot = Instantiate(fire, firePos.transform.position, firePos.transform.rotation);
                Rigidbody2D rb = shoot.GetComponent<Rigidbody2D>();

                // Finde die Richtung zum Spieler
                Vector3 directionToPlayer = (player.transform.position - shoot.transform.position).normalized;

                // Wende eine Kraft in Richtung des Spielers an
                rb.AddForce(directionToPlayer * force, ForceMode2D.Impulse);
                canFire = false;
                ps = shoot.GetComponentInChildren<ParticleSystem>();

                // Falls das Partikelsystem gefunden wurde, setze seine Geschwindigkeit
                if (ps != null)
                {
                    // Berechne die Rotation, die notwendig ist, damit das Partikelsystem in die gewünschte Richtung zeigt
                    Quaternion rotationToPlayer = Quaternion.LookRotation(Vector3.forward, directionToPlayer);

                    // Setze die Rotation des Partikelsystems
                    ps.transform.rotation = rotationToPlayer;
                }
            }
        }
        if (distanceBeforeTwo <= distance)
        {
            if (schussFertig)
            {
                
                    StartCoroutine(PlaySchussWithDelay());
                    schussFertig = false;
                
            }
            if (kreis)
            {
                
                    StartCoroutine(PlayKreisWithDelay());
                    kreis = false;
                
            }
            if (kreuz)
            {
                {
                    
                    StartCoroutine(PlayKreuzWithDelay());
                    kreuz = false;
                    
                }
                
            }
            if (schwach)
            {

                if (schwachLinks)
                {
                    StartCoroutine(PlayLowWithDelay());
                    schwach = false;
                }
                if (schwachRechts)
                {
                    StartCoroutine(PlayLowRechtsWithDelay());
                    schwach = false;
                }

            }
        }
            
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PlayKreisWithDelay());
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(PlaySchussWithDelay());
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(PlayKreuzWithDelay());
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(PlayLowWithDelay());
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(PlayLowRechtsWithDelay());
        }
        distanceBeforeTwo = Vector2.Distance(transform.position, player.transform.position);

    }
    IEnumerator PlayKreisWithDelay()
    {
        // Play the animation on the first dragon
        anim.Play("DragonForOne");
        // Wait for one second
        yield return new WaitForSeconds(1f);
        //src1.Play();
        // Deactivate the first dragon
        dragon.SetActive(false);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(true);
        // Wait for one second

        // Play the animation on the second dragon
        anim2.Play("DracheN1");
        yield return new WaitForSeconds(3f);
        anim2.Play("DracheNZ");
        yield return new WaitForSeconds(1f);
        // Deactivate the first dragon
        dragon.SetActive(true);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(false);
        anim.Play("DracheForTwo");
        yield return new WaitForSeconds(1f);
        anim.Play("DragonForIdle");
        yield return new WaitForSeconds(2f);
        kreuz = true;
    }
    IEnumerator PlaySchussWithDelay()
    {
        
        // Play the animation on the first dragon
        anim.Play("DragonForOne");
        // Wait for one second
        yield return new WaitForSeconds(1f);

        // Deactivate the first dragon
        dragon.SetActive(false);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(true);
        // Wait for one second
        anim2.Play("DracheN3");
        yield return new WaitForSeconds(1f);
        // Play the animation on the second dragon
        schuss = true;
        anim2.Play("DracheH4");
        yield return new WaitForSeconds(6f);
        schuss = false;
        anim2.Play("DracheNZ");
        yield return new WaitForSeconds(1f);
        // Deactivate the first dragon
        dragon.SetActive(true);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(false);
        anim.Play("DracheForTwo");
        yield return new WaitForSeconds(1f);
        anim.Play("DragonForIdle");
        yield return new WaitForSeconds(2f);
        kreis = true;

    }
    IEnumerator PlayKreuzWithDelay()
    {
        // Play the animation on the first dragon
        anim.Play("DragonForOne");
        // Wait for one second
        yield return new WaitForSeconds(1f);

        // Deactivate the first dragon
        dragon.SetActive(false);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(true);
        // Wait for one second
        // Play the animation on the second dragon
        anim2.Play("DracheN5");
        yield return new WaitForSeconds(4.5f);
        anim2.Play("DracheNZ");
        yield return new WaitForSeconds(1f);
        // Deactivate the first dragon
        dragon.SetActive(true);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(false);
        anim.Play("DracheForTwo");
        yield return new WaitForSeconds(1f);
        anim.Play("DragonForIdle");
        yield return new WaitForSeconds(2f);

        schwach = true;
    }
    IEnumerator PlayLowWithDelay()
    {
        // Play the animation on the first dragon
        anim.Play("DragonForOne");
        // Wait for one second
        yield return new WaitForSeconds(1f);

        // Deactivate the first dragon
        dragon.SetActive(false);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(true);
        // Wait for one second
        // Play the animation on the second dragon
        anim2.Play("DracheNoEnergy");
        yield return new WaitForSeconds(1f);
        inju = true;
        anim2.Play("DracheNoEnergyIdle");
        yield return new WaitForSeconds(7f);
        inju = false;
        anim2.Play("DracheNoEnergyBack");
        yield return new WaitForSeconds(1f);
        // Deactivate the first dragon
        dragon.SetActive(true);
        // Wait for one second
        // Activate the second dragon
        dragon2.SetActive(false);
        anim.Play("DracheForBasic");
        yield return new WaitForSeconds(1f);
        anim.Play("DragonForIdle");
        yield return new WaitForSeconds(2f);
        kreuz = false;
        kreis = false;
        schussFertig = true;
    }
    IEnumerator PlayLowRechtsWithDelay()
    {
        
        // Play the animation on the first dragon
        anim.Play("DragonForOne");
        // Wait for one second
        yield return new WaitForSeconds(1f);

        // Deactivate the first dragon
        dragon.SetActive(false);
        // Wait for one second

        // Activate the second dragon
        dragon2.SetActive(true);
        // Wait for one second
        // Play the animation on the second dragon
        anim2.Play("DracheNoEnergyRechts");
        yield return new WaitForSeconds(1f);
        inju = true;
        anim2.Play("DracheNoEnergyRechtIdles");
        yield return new WaitForSeconds(7f);
        inju = false;
        anim2.Play("DracheNoEnergyRechtsBack");
        yield return new WaitForSeconds(1f);
        // Deactivate the first dragon
        dragon.SetActive(true);
        // Wait for one second
        // Activate the second dragon
        dragon2.SetActive(false);
        anim.Play("DracheForBasic");
        yield return new WaitForSeconds(1f);
        anim.Play("DragonForIdle");
        yield return new WaitForSeconds(2f);

        kreuz = false;
        kreis = false;
        schussFertig = true;
    }

}
