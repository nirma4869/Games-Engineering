using BehaviorDesigner.Runtime.Tasks.Unity.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float force;
    public float minAngle;
    public float maxAngle;
    public Vector3 rotation;
    public GameObject handGun;
    public AudioSource src;
    public float horizontalInput;
    public float verticalInput;
    public Vector3 rightStickDirection;
    public Vector3 stickWorldPos;
    public float rotationSpeed = 5f;
    public Transform target;  // Das Objekt, um das sich dieses Objekt drehen soll
    public float radius = 1.0f;
    public float angle;// Der Abstand zum Zielobjekt
    public bool controller, maus;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Lies die Eingaben vom rechten Analogstick
        float horizontal = Input.GetAxis("RightStickHorizontal");
        float vertical = Input.GetAxis("RightStickVertical");
        if (controller)
        {
            // 1. Eingabe des rechten Analogsticks (hier als Beispiel für die Horizontalachse)
            

            // 2. Berechnung der Zielrotation basierend auf der Eingabe
            Vector3 directionToStick = new Vector3(horizontal, vertical, 0f);
            Vector3 targetPosition = target.position + directionToStick;

            // 3. Drehung des rotierenden Objekts
            Vector3 directionToTarget = targetPosition - transform.position;
            float angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angleToTarget, Vector3.forward);

            // 4. Anwenden der Rotation auf das rotierende Objekt
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);

        }
        //ya
        if (maus)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            //   float limitedRotZ = Mathf.Clamp(rotZ, minAngle, maxAngle);
            //Wenn mit controller dann das nutzen

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        SpriteRenderer sr = handGun.GetComponent<SpriteRenderer>();

        if(rotation.y >= 0 || angle >= 0 )
        {
            sr.sortingOrder = 7;
        }
        if (rotation.y < 0 || angle < 0)
        {
            sr.sortingOrder = 9;
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }

        }

        if (Input.GetMouseButton(0) && canFire || Input.GetKeyDown(KeyCode.JoystickButton7) && canFire)
        {
            src.Play();
            GameObject shoot = Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
            Rigidbody2D rb = shoot.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletTransform.up *  -force, ForceMode2D.Impulse);
            shoot.transform.tag = "Gun";
            canFire = false;
            
        }
    }
}
