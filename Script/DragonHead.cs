using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHead : MonoBehaviour
{
    public HealthbarBehaviour healthbarBehaviour;
    public float Hitpoints;
    public float MaxHitpoints;
    public Dragon dragon;
    public GameObject dragobOnject;
    public Material aktuell, weiﬂ;
    public SpriteRenderer sr;
    public CharacterControllerMaus ccm;

    // Start is called before the first frame update
    void Start()
    {
        ccm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMaus>();
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);
        TakeHit(1);
        aktuell = sr.material;

    }

    // Update is called once per frame
    void Update()
    {
        if (dragon.inju)
        {
            if (Hitpoints < MaxHitpoints)
            {
                healthbarBehaviour.Slider.gameObject.SetActive(true);
            }
            transform.tag = "Nichts";
        }
        if (!dragon.inju)
        {
            healthbarBehaviour.Slider.gameObject.SetActive(false);
            transform.tag = "Drache";

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dragon.inju)
        {
            if (collision.gameObject.tag == "Gun")
            {
                TakeHit(10);
                StartCoroutine(gotHit());
            }
            else if (collision.gameObject.tag == "Trident")
            {
                TakeHit(20);
                StartCoroutine(gotHit());
            }

            else if (collision.gameObject.tag == "Player")
            {
                //  Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
                //  transform.position += repelDirection * repelForce * Time.deltaTime;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dragon.inju)
        {

            if (collision.gameObject.CompareTag("Sword"))
            {

                TakeHit(30);
                StartCoroutine(gotHit());

            }
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
            Destroy(dragobOnject);
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
