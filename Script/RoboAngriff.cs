using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAngriff : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 playerPos;
    public Vector3 rotation;
    public Transform robo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rotation = playerPos - robo.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //   float limitedRotZ = Mathf.Clamp(rotZ, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
       
    }
}
