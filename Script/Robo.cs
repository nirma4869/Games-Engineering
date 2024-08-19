using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour
{
    public float speed = 40f;


    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    public GameObject player;
    public Vector3 moveDir;
    public Animator anim;
    public float distanceBefore;
    public float distanceBeforeTwo;
    public float force;
    public float repelForce;
    public float gunForce;
    public float swordForce;
    public float tridentForce;
    public HealthbarBehaviour healthbarBehaviour;
    public float Hitpoints;
    public float MaxHitpoints = 500;
    public GameObject laserPos;
    public GameObject laser;
    public bool drin;
    public bool drinConfirm;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public BoxCollider2D boxCollider;
    public Material aktuell, weiﬂ;
    public SpriteRenderer sr;
    public CharacterControllerMaus ccm;
    public AudioSource src;

    private void Start()
    {
        ccm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMaus>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);
        aktuell = sr.material;


    }

    private void Update()
    {
        distanceBeforeTwo = Vector2.Distance(transform.position, player.transform.position);
        HandleMovement();

        SetTargetPosition(player.transform.position);
        if(distanceBeforeTwo <= 15f)
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
                GameObject shoot = Instantiate(laser, laserPos.transform.position, laserPos.transform.rotation);
                Rigidbody2D rb = shoot.GetComponent<Rigidbody2D>();
                src.Play();
                // Finde die Richtung zum Spieler
                Vector3 directionToPlayer = (player.transform.position - shoot.transform.position).normalized;

                // Wende eine Kraft in Richtung des Spielers an
                rb.AddForce(directionToPlayer * force, ForceMode2D.Impulse);
                canFire = false;
            }
            if (distanceBeforeTwo <= 6f)
            {
                pathVectorList = null;
            }

        }
        
        

    }

    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 0.5f)
            {
                moveDir = (targetPosition - transform.position).normalized;

                distanceBefore = Vector3.Distance(transform.position, targetPosition);
              

                transform.position = transform.position + moveDir * speed * Time.deltaTime;

                if (moveDir.x > 0.5f)
                {
                    anim.Play("rechts");

                }
                else if (moveDir.x < -0.5f)
                {
                    anim.Play("links");


                }
                else if (moveDir.y > 0.5f)
                {
                    anim.Play("oben");

                }
                else if (moveDir.y < -0.5f)
                {
                    anim.Play("unten");


                }
                else if (moveDir.y > 0.5f && moveDir.x > 0.5f)
                {
                    anim.Play("oben");

                }
                else if (moveDir.y < -0.5f && moveDir.y < -0.5f)
                {
                    anim.Play("unten");


                }
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();

                }
            }
        }
        else
        {

        }
    }

    private void StopMoving()
    {
        pathVectorList = null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Gun")
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * gunForce * Time.deltaTime;
            TakeHit(5);
            StartCoroutine(gotHit());
        }
        else if (collision.gameObject.tag == "Trident")
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * tridentForce * Time.deltaTime;
            TakeHit(15);
            StartCoroutine(gotHit());
        }

        else if (collision.gameObject.tag == "Player")
        {
          //  Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
          //  transform.position += repelDirection * repelForce * Time.deltaTime;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


            if (collision.gameObject.CompareTag("Sword"))
            {

                Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
                transform.position += repelDirection * swordForce * Time.deltaTime;
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
