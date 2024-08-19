using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    // Singleton-Instanz des GameManagers
    public static GameManager instance;
    public GameObject schwert, gun, dreizack,herz;
    public GameObject gegner,sceneObj;
    public int zahl;
    public bool start;
    public ParticleSystem ps;
    public List<GameObject> enemyList = new List<GameObject>();
    GameObject[] vogels; 
    GameObject[] stein; 
    GameObject[] robo; 
    GameObject[] steinKugel;
    GameObject[] drache;
    public bool no;
    public CharacterControllerMaus cm;

    // Start is called before the first frame update
    void Awake()
    {
        // Singleton-Implementierung
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        /*
        no = false;
        InitObjects();
        sceneObj.SetActive(false);
        gegner.SetActive(false);
        schwert.SetActive(false);
        gun.SetActive(false);
        dreizack.SetActive(false);
        herz.SetActive(false);
        getWaffe();
        */
    }

    // Update is called once per frame
    void Update()
    {
        vogels = GameObject.FindGameObjectsWithTag("Vogel");
      stein = GameObject.FindGameObjectsWithTag("Stein");
        robo = GameObject.FindGameObjectsWithTag("Robo");
        steinKugel = GameObject.FindGameObjectsWithTag("SteinKugel");
        drache = GameObject.FindGameObjectsWithTag("Drache");

        if (start)
        {
            ps.Play();
            gegner.SetActive(true);
            start = false;
        }
        foreach (GameObject vogel in vogels)
        {
            if (!enemyList.Contains(vogel))
            {
                AddEnemyToList(vogel);
                no = true;
            }
        }
        foreach (GameObject s in stein)
        {
            if (!enemyList.Contains(s))
            {
                AddEnemyToList(s);
                no = true;
            }
        }
        foreach (GameObject r in robo)
        {
            if (!enemyList.Contains(r))
            {
                AddEnemyToList(r);
                no = true;
            }
        }
        foreach (GameObject sk in steinKugel)
        {
            if (!enemyList.Contains(sk))
            {
                AddEnemyToList(sk);
                no = true;
            }
        }
        foreach (GameObject d in drache)
        {
            if (!enemyList.Contains(d))
            {
                AddEnemyToList(d);
                no = true;
            }
        }

        // Entferne deaktivierte GameObjects aus der Liste
        enemyList.RemoveAll(item => item == null || !item.activeInHierarchy);

        if (no && enemyList.Count == 0)
        {
            sceneObj.SetActive(true);
            cm.gun = false;
            cm.noWeapon = true;
            cm.trident = false;
            cm.sword = false;

        }

    }
    // Methode zur Initialisierung der Objekte
    void InitObjects()
    {
        schwert = GameObject.FindGameObjectWithTag("SchwertDa");
        gun = GameObject.FindGameObjectWithTag("WaffeDa");
        dreizack = GameObject.FindGameObjectWithTag("DreizackDa");
        herz = GameObject.FindGameObjectWithTag("Herz");
        gegner = GameObject.FindGameObjectWithTag("EinfacheGegner");
        ps = GameObject.FindGameObjectWithTag("start").GetComponent<ParticleSystem>();
        sceneObj = GameObject.FindGameObjectWithTag("scene");
        cm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerMaus>();
        

    }
    public void getWaffe()
    {
        zahl = Random.Range(1, 4);
        if(zahl == 1)
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

    public void getGegner()
    {
        ps.Play();
        gegner.SetActive(true);

    }
    public void AddEnemyToList(GameObject obj)
    {
        if (obj != null)
        {
            enemyList.Add(obj);
        }

    }

    public void getEnemy()
    {
        foreach (GameObject vogel in vogels)
        {
            enemyList.Add(vogel);
        }
        foreach (GameObject s in stein)
        {
            enemyList.Add(s);
        }
        foreach (GameObject r in robo)
        {
            enemyList.Add(r);
        }
        foreach (GameObject sk in steinKugel)
        {
            enemyList.Add(sk);
        }
    }
    public void everyTime()
    {
        no = false;
        InitObjects();
        sceneObj.SetActive(false);
        gegner.SetActive(false);
        schwert.SetActive(false);
        gun.SetActive(false);
        dreizack.SetActive(false);
        herz.SetActive(false);
        getWaffe();
    }

    public void toDragon()
    {
        sceneObj.SetActive(true);
    }

   
}
