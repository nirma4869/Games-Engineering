using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControllerMaus : MonoBehaviour
{
    public float dir;
    public float verDir;
    public Rigidbody2D rb;
    public float speed = 3;
    public Animator animator;
    public bool rechts, links, unten, oben;
    public bool noWeapon, gun, sword, trident;
    public Vector3 mousePos;
    public Vector3 rotation;
    private Camera mainCam;
    public float rotZ;
    public GameObject gunO, dreiO,swordO;
    public GameObject player;
    public int force = 3;
    public float repelForce = 100f;
    public CharacterHealthbarBehaviour healthbarBehaviour;
    public float Hitpoints;
    public float MaxHitpoints;
    public Material aktuell, weiﬂ;
    public SpriteRenderer sr;
    private static CharacterControllerMaus playerInstance;
    public TextMeshProUGUI counterText;
    public int counter;
    public AudioSource src;
    public float sensitivity = 1.0f;
    public float horizontalInput;
    public float verticalInput;
    public Vector3 rightStickDirection;
    public Vector3 stickWorldPos;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        noWeapon = true;
        player = GameObject.FindGameObjectWithTag("Player");
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);
        //TakeHit(0.0000000000000001f);
        //BackHit(0.00001f);
        aktuell = sr.material;
        counter = 0;
        counterText.text = "Deaths: " + $"{counter}";
    }

    // Update is called once per frame
    void Update()
    {
        // Werte des rechten Analogsticks lesen
         horizontalInput = Input.GetAxis("RightStickHorizontal");
         verticalInput = Input.GetAxis("RightStickVertical");

        // Normalisieren der Eingabewerte, um eine Richtung zu bekommen
         rightStickDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // Wenn es eine Eingabe gibt, berechnen der Rotation
        
            // Berechnen des Weltpunkts basierend auf der Position des Spielobjekts und der Richtung des rechten Analogsticks
            stickWorldPos = transform.position + rightStickDirection;

            // Berechnen der Richtung zur Rotation
            rotation = stickWorldPos - transform.position;
        

        // DaVOR
        healthbarBehaviour.Slider.value = Hitpoints;
        player.transform.position = new Vector3(transform.position.x,transform.position.y,0);
        dir = Input.GetAxis("Horizontal");
        verDir = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(0, 0);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        if (dir == 0 && verDir == 0)
        {
            src.gameObject.SetActive(false);
        }
        if (dir > 0 || verDir > 0 || dir < 0 || verDir < 0)
        {
            src.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gun = true;
            noWeapon = false;
            trident = false;
            sword = false; 
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            gun = false;
            noWeapon = false;
            trident = true;
            sword = false; ;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(player.transform.up * force, ForceMode2D.Force);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gun = false;
            noWeapon = false;
            trident = false;
            sword = true; ;
        }
        if (noWeapon)
        {
            gunO.SetActive(false);
            dreiO.SetActive(false);
            swordO.SetActive(false);
        }
        if (trident)
        {
            gunO.SetActive(false);
            dreiO.SetActive(true);
            swordO.SetActive(false);
        }
        if (sword)
        {
            gunO.SetActive(false);
            dreiO.SetActive(false);
            swordO.SetActive(true);
        }
        if (gun)
        {
            gunO.SetActive(true);
            dreiO.SetActive(false);
            swordO.SetActive(false);
        }
        if (noWeapon)
        {
            gun = false;
            sword = false;
            trident = false;
            gunO.SetActive(false);
            dreiO.SetActive(false);
            // hGun.SetActive(false);
            if (dir == 0 && verDir == 0)
            {
                if (oben)
                {
                    animator.Play("obenIdle");
                }
                if (unten)
                {
                    animator.Play("untenIdle");
                }
                if (links || unten && links || oben && links)
                {
                    animator.Play("linksIdle");
                }
                if (rechts || unten && rechts || oben && rechts)
                {
                    animator.Play("rechtsIdle");
                }
            }
            else if (dir > 0 && verDir < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                animator.Play("rechts_walk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir > 0 && verDir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                animator.Play("rechts_walk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                animator.Play("linksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                animator.Play("linksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                animator.Play("rechts_walk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;

            }
            else if (dir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                animator.Play("linksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;

            }
            else if (verDir > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                animator.Play("obelWalk");
                rechts = false;
                links = false;
                oben = true;
                unten = false;

            }
            else if (verDir < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                animator.Play("untenWalk");
                rechts = false;
                links = false;
                oben = false;
                unten = true;
            }
        }
        if (gun)
        {

            noWeapon = false;
            sword = false;
            trident = false;
            gunO.SetActive(true);
            dreiO.SetActive(false);

            if (dir > 0 && verDir < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir > 0 && verDir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rechts = true;
                links = false;
                oben = false;
                unten = false;

            }
            else if (dir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rechts = false;
                links = true;
                oben = false;
                unten = false;

            }
            else if (verDir > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                rechts = false;
                links = false;
                oben = true;
                unten = false;

            }
            else if (verDir < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                rechts = false;
                links = false;
                oben = false;
                unten = true;
            }
            if (dir != 0 || verDir != 0)
            {
                if (rotation.x >= -1 && rotation.x <= 1 && rotation.y < 0)
                {
                    animator.Play("gunUntenWalk");
                }
                else if (rotation.x >= -1 && rotation.x <= 1 && rotation.y > 0)
                {
                    animator.Play("gunObenWalk");
                }
                else if (rotation.x >= 0)
                {
                    animator.Play("gunRechtsWalk");
                }
                else if (rotation.x < 0)
                {
                    animator.Play("gunLinksWalk");
                }
            }
            if (dir == 0 && verDir == 0)
            {
                if (rotation.x >= -1 && rotation.x <= 1 && rotation.y < 0)
                {
                    animator.Play("gunUntenIdle");
                }
                else if (rotation.x >= -1 && rotation.x <= 1 && rotation.y > 0)
                {
                    animator.Play("gunObenIdle");
                }
                else if (rotation.x >= 0)
                {
                    animator.Play("gunRechtsIdle");
                }
                else if (rotation.x < 0)
                {
                    animator.Play("gunLinksIdle");
                }
            }
           



            }
        if (trident || sword)
        {
            gun = false;
            noWeapon = false;
            gunO.SetActive(false);
            if (trident)
            {
                dreiO.SetActive(true);
            }
            if (sword)
            {
                swordO.SetActive(true);
            }

            if (dir > 0 && verDir < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir > 0 && verDir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rechts = true;
                links = false;
                oben = false;
                unten = false;

            }
            else if (dir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rechts = false;
                links = true;
                oben = false;
                unten = false;

            }
            else if (verDir > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                rechts = false;
                links = false;
                oben = true;
                unten = false;

            }
            else if (verDir < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                rechts = false;
                links = false;
                oben = false;
                unten = true;
            }
            if (dir != 0 || verDir != 0)
            {
                if (rotation.x >= -1 && rotation.x <= 1 && rotation.y < 0)
                {
                    animator.Play("DreiUntenWalk");
                }
                else if (rotation.x >= -1 && rotation.x <= 1 && rotation.y > 0)
                {
                    animator.Play("DreiObenWalk");
                }
                else if (rotation.x >= 0)
                {
                    animator.Play("DreiRechtsWalk");
                }
                else if (rotation.x < 0)
                {
                    animator.Play("DreiLinksWalk");
                }
            }
            if (dir == 0 && verDir == 0)
            {
                if (rotation.x >= -1 && rotation.x <= 1 && rotation.y < 0)
                {
                    animator.Play("DreiUntenIdle");
                }
                else if (rotation.x >= -1 && rotation.x <= 1 && rotation.y > 0)
                {
                    animator.Play("DreiObenIdle");
                }
                else if (rotation.x >= 0)
                {
                    animator.Play("DreiRechtsIdle");
                }
                else if (rotation.x < 0)
                {
                    animator.Play("DreiLinksIdle");
                }
            }

        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Wenn der Spieler den Gegner ber¸hrt, stoﬂen sie sich beide ab
        if (collision.gameObject.CompareTag("Vogel"))
        {
               Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
               transform.position += repelDirection * repelForce * Time.deltaTime;
            TakeHit(1);
            StartCoroutine(gotHit());
        }
        // Wenn der Spieler den Gegner ber¸hrt, stoﬂen sie sich beide ab
        if (collision.gameObject.CompareTag("Robo"))
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * repelForce * Time.deltaTime;
            TakeHit(1);
            StartCoroutine(gotHit());
        }
        // Wenn der Spieler den Gegner ber¸hrt, stoﬂen sie sich beide ab
        if (collision.gameObject.CompareTag("Stein"))
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * repelForce * Time.deltaTime;
            TakeHit(1);
            StartCoroutine(gotHit());
        }
        if (collision.gameObject.CompareTag("SteinKugel"))
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * repelForce * Time.deltaTime;
            TakeHit(3);
            StartCoroutine(gotHit());
        }
        if (collision.gameObject.CompareTag("Drache"))
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * repelForce * Time.deltaTime;
            TakeHit(5);
            StartCoroutine(gotHit());
        }
        if (collision.gameObject.tag == "WaffeDa")
        {
            gun = true;
            noWeapon = false;
            trident = false;
            sword = false;
        //    Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            GameManager.instance.getGegner();
            GameManager.instance.getEnemy();

        }
        if (collision.gameObject.tag == "SchwertDa")
        {
            gun = false;
            noWeapon = false;
            trident = false;
            sword = true;
          //  Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            GameManager.instance.getGegner();
            GameManager.instance.getEnemy();


        }
        if (collision.gameObject.tag == "DreizackDa")
        {
            gun = false;
            noWeapon = false;
            trident = true;
            sword = false;
         //   Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            GameManager.instance.getGegner();
            GameManager.instance.getEnemy();
        }
        if (collision.gameObject.tag == "Herz")
        {
            Hitpoints = MaxHitpoints;
            healthbarBehaviour.Slider.value = MaxHitpoints;
            healthbarBehaviour.SetHealth(MaxHitpoints, MaxHitpoints);
        //    Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            //GameManager.instance.getGegner();
            //GameManager.instance.toDragon();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RoboLaser"))
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * repelForce * Time.deltaTime;
            TakeHit(1);
            StartCoroutine(gotHit());
        }
        if (collision.gameObject.CompareTag("DrachenBall"))
        {
            Vector3 repelDirection = (transform.position - collision.transform.position).normalized;
            transform.position += repelDirection * repelForce * Time.deltaTime;
            TakeHit(1);
            StartCoroutine(gotHit());
        }
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);
        healthbarBehaviour.then = true;

        if (Hitpoints <= 0)
        {
            counter++;
            counterText.text = "Deaths: " + $"{counter}";
            gun = false;
            noWeapon = true;
            trident = false;
            sword = false;
            SceneManager.LoadScene("RoomScene");
        }
    }
    public void BackHit(float damage)
    {
        Hitpoints += damage;
        healthbarBehaviour.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
        //    SceneManager.LoadScene("RoomScene");
        }
    }
    IEnumerator gotHit()
    {
        sr.material = weiﬂ;
        yield return new WaitForSeconds(0.1f);
        sr.material = aktuell;
        yield return new WaitForSeconds(0.1f);
        sr.material = weiﬂ;
        yield return new WaitForSeconds(0.1f);
        sr.material = aktuell;
    }
}
