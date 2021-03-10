using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = -1;
    public bool pounce = false;
    public damageplayer damage;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D edge = Physics2D.Raycast(transform.position, new Vector2(3*speed, -1), 5, 1); // OBS VIKTIGT MÅSTE VARA PÅ LAGER 1 FÖR ATT FUNGERA
        Debug.DrawRay(transform.position, new Vector3(3 * speed, -1), Color.white);
        if (pounce == false)
        {
            if (edge.collider == null)
            {
                speed = -speed;
            }
        }

        RaycastHit2D groundcheck = Physics2D.Raycast(transform.position, new Vector2(0,-2), 1, 1);
        Debug.DrawRay(transform.position, new Vector2(0, -1), Color.white);
        if (groundcheck.collider != null)
        {
            pounce = false;
            StartCoroutine(jumps());
        }

        RaycastHit2D playercheck = Physics2D.Raycast(transform.position, new Vector2(5 * speed, 0), 5, 1);
        Debug.DrawRay(transform.position, new Vector3(5 * speed, 0), Color.white);

        if (playercheck.collider != null)
        {
            StartCoroutine(attack());
        }
    }
    IEnumerator jumps()
    {
        yield return new WaitForSeconds(1);
        pounce = true;
        body.velocity = new Vector2(speed, 4);
    }
    IEnumerator attack()
    {
        yield return new WaitForSeconds(1);
        pounce = true;
        body.velocity = new Vector2( speed*4, 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damage = collision.gameObject.GetComponent<damageplayer>();
            damage.health--;
            print(damage.health);
        }
    }
}
