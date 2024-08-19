using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public ParticleSystem ps;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GameObject light;
    public BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        // Finde alle Collider im Spiel, die das angegebene Tag haben
     //   GameObject objectToAvoid = GameObject.FindGameObjectWithTag("Enemy");

        // Ignoriere Kollisionen zwischen diesem Collider und allen gefundenen Collidern mit dem angegebenen Tag
       
    //    Collider2D colliderToAvoid = objectToAvoid.GetComponent<Collider2D>();
      //      if (colliderToAvoid != null)
      //      {
      //          Physics2D.IgnoreCollision(GetComponent<Collider2D>(), colliderToAvoid, true);
      //      }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player") || collision.CompareTag("Wand"))
        {
            
            StartCoroutine(showParticle());

        }


    }

    IEnumerator showParticle()
    {
        spriteRenderer.color = new Vector4(0, 0, 0, 0);
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
        light.SetActive(false);
        ps.gameObject.SetActive(true);
        boxCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(this.gameObject);

    }
}
