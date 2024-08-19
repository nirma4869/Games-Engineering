using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinSchuss : MonoBehaviour
{
    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    private GameObject player;
    private Vector3 moveDir;
    private float distanceBefore;
    private float distanceBeforeTwo;
    private float force = 4f;
    private float repelForce = 100f;
    private float gunForce = 25f;
    private float swordForce = 150f;
    private float tridentForce = 125f;
    private HealthbarBehaviour healthbarBehaviour;
    private float Hitpoints = 30f;
    private float MaxHitpoints = 30f;
    private bool canFire;
    private float timeBetweenFiring = 5f;
    private float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        healthbarBehaviour = GetComponentInChildren<HealthbarBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);
     
    }

    // Update is called once per frame
    void Update()
    {
        distanceBeforeTwo = Vector2.Distance(transform.position, player.transform.position);
        HandleMovement();

        SetTargetPosition(player.transform.position);
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
        }
        else if (collision.gameObject.tag == "Trident")
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * tridentForce * Time.deltaTime;
            TakeHit(15);
        }

        else if (collision.gameObject.tag == "Player")
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * repelForce * Time.deltaTime;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * swordForce * Time.deltaTime;
            TakeHit(10);
        }
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
