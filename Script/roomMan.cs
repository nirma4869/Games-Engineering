using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomMan : MonoBehaviour
{
    public CharacterControllerMaus cm;
    public GameObject player;
    public GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = pos.transform.position;
        cm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMaus>();
        cm.Hitpoints = cm.MaxHitpoints;
        cm.healthbarBehaviour.Slider.value = cm.MaxHitpoints;
        cm.healthbarBehaviour.SetHealth(cm.MaxHitpoints, cm.MaxHitpoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
