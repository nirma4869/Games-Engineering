using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GameObject light;
    public BoxCollider2D boxCollider;
    public BoxCollider2D boxCollider2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(showParticle());

    }

    IEnumerator showParticle()
    {
        spriteRenderer.color = new Vector4(0, 0, 0, 0);
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
        light.SetActive(false);
        ps.gameObject.SetActive(true);
        boxCollider.enabled = false;
        boxCollider2.enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(this.gameObject);

    }
}
