using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dreizack : MonoBehaviour
{
    public Rigidbody2D rb;
    public CharacterControllerMaus ccm;
    public GameObject player;
    public bool coll;
    public GameObject rpd;
    public ShootingDrei sd;
    float speed;
    public ParticleSystem ps,ps2;
    private Vector2 collisionPoint;
    public AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        ccm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMaus>();
        rpd = GameObject.FindGameObjectWithTag("RPD");
        sd = GameObject.FindGameObjectWithTag("RPD").GetComponent<ShootingDrei>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        speed = 20f;
        if (coll)
        {
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
            if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.JoystickButton6))
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        src.gameObject.SetActive(true);
        rb.velocity = new Vector2(0, 0);
        coll = true;
        ps.gameObject.SetActive(true);
        // Hol dir den ersten Kontaktpunkt
        ContactPoint2D contact = collision.contacts[0];
        // Speichere die Position des Aufpralls
        collisionPoint = contact.point;
        ps.gameObject.transform.position = collisionPoint;
        ps.transform.SetParent(null);
        ps2.gameObject.SetActive(false);
        sd.canFire = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (coll)
            {
                
                gameObject.SetActive(false);
                Destroy(ps.gameObject);
                Destroy(gameObject);
                ccm.noWeapon = false;
                ccm.trident = true;
                rpd.SetActive(true);
                sd.canFire = true;
            }
        }
    }

}
