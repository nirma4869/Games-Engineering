using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartStopMoving : MonoBehaviour
{
    CharacterPathfindingMovementHandler cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CharacterPathfindingMovementHandler>();
        cm.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform.tag == "Player")
        {
            cm.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cm.enabled = false;
    }
}
