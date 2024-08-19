using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDrei : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject dreiO;
    public Transform dreiPos;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float force;
    public float minAngle;
    public float maxAngle;
    public Vector3 rotation;
    public CharacterControllerMaus ccm;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //   float limitedRotZ = Mathf.Clamp(rotZ, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        SpriteRenderer sr = dreiO.GetComponent<SpriteRenderer>();


       

        if (Input.GetMouseButton(0) && canFire || Input.GetKeyDown(KeyCode.JoystickButton7) && canFire)
        {

            GameObject shoot = Instantiate(dreiO, dreiPos.position, dreiPos.rotation);
            Rigidbody2D rb = shoot.GetComponent<Rigidbody2D>();
            rb.AddForce(dreiPos.up * force, ForceMode2D.Impulse);
            ccm.trident = false;
            ccm.noWeapon = true;
            canFire = false;
            shoot.gameObject.tag = "Trident";
        }

    }
   
}
