using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinAuge : MonoBehaviour
{
    public Vector3 augeRotation;
    public Vector3 playerPos;
    public float orbitSpeed;
    public GameObject schuss;
    public bool canFire;
    public GameObject player;
    private float timer;
    public float timeBetweenFiring;
    public GameObject auge;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        augeRotation = playerPos - transform.position;
        // Winkel berechnen, um das Child-Objekt in Richtung des Spielers zu drehen
        float angle = Mathf.Atan2(augeRotation.y, augeRotation.x) * Mathf.Rad2Deg;
        angle -= -90f;
        // Rotation setzen
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

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
            GameObject shoot = Instantiate(schuss, auge.transform.position, auge.transform.rotation);

            // Wende eine Kraft in Richtung des Spielers an
            canFire = false;
        }
    }
}

