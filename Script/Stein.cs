using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stein : MonoBehaviour
{
    private HealthbarBehaviour healthbarBehaviour;
    private float repelForce = 100f;
    private float gunForce = 25f;
    private float swordForce = 150f;
    private float tridentForce = 125f;
    private float Hitpoints = 50f;
    private float MaxHitpoints = 50f;
    public Material aktuell, weiﬂ;
    public SpriteRenderer sr;
    public CharacterControllerMaus ccm;

    // Start is called before the first frame update
    void Start()
    {
        ccm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMaus>();

        healthbarBehaviour = GetComponentInChildren<HealthbarBehaviour>();
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);
        aktuell = sr.material;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Gun")
        {

            TakeHit(5);
            StartCoroutine(gotHit());
        }
        else if (collision.gameObject.tag == "Trident")
        {

            TakeHit(15);
            StartCoroutine(gotHit());
        }

        else if (collision.gameObject.tag == "Player")
        {


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {

            TakeHit(10);
            StartCoroutine(gotHit());
        }
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {

            ccm.MaxHitpoints++;
            ccm.healthbarBehaviour.SetHealth(ccm.Hitpoints, ccm.MaxHitpoints);
            Destroy(gameObject);
        }
    }
    IEnumerator gotHit()
    {
        sr.material = weiﬂ;
        yield return new WaitForSeconds(0.1f);
        sr.material = aktuell;
        yield return new WaitForSeconds(0.1f);
        sr.material = weiﬂ;
        yield return new WaitForSeconds(0.1f);
        sr.material = aktuell;
    }
}
