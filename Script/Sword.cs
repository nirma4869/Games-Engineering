using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public Vector3 rotation;
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //   float limitedRotZ = Mathf.Clamp(rotZ, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        SpriteRenderer sr = sword.GetComponent<SpriteRenderer>();
        if (rotation.y >= 0)
        {
            sr.sortingOrder = 7;
        }
        if (rotation.y < 0)
        {
            sr.sortingOrder = 9;
        }
    }
}
