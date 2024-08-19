using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behave : MonoBehaviour
{
    public GameObject schwert, gun, dreizack, herz;
    public GameObject gegner;
    public Waffen waffen;
    public int zahl;
    // Start is called before the first frame update
    void Start()
    {
        
        schwert = GameObject.FindGameObjectWithTag("SchwertDa");
        gun = GameObject.FindGameObjectWithTag("WaffeDa");
        dreizack = GameObject.FindGameObjectWithTag("DreizackDa");
        herz = GameObject.FindGameObjectWithTag("Herz");
        gegner = GameObject.FindGameObjectWithTag("EinfacheGegner");
        schwert.SetActive(false);
        gun.SetActive(false);
        dreizack.SetActive(false);
        herz.SetActive(false);
        gegner.SetActive(false);
        getWaffe();
    }

    // Update is called once per frame
    void Update()
    {
        if (waffen.started)
        {
            gegner.SetActive(true);
        }
    }

    public void getWaffe()
    {
        zahl = Random.Range(1, 4);
        if (zahl == 1)
        {
            schwert.SetActive(true);
            gun.SetActive(false);
            dreizack.SetActive(false);
        }
        if (zahl == 2)
        {
            schwert.SetActive(false);
            gun.SetActive(true);
            dreizack.SetActive(false);
        }
        if (zahl == 3)
        {
            schwert.SetActive(false);
            gun.SetActive(false);
            dreizack.SetActive(true);
        }
    }
}
