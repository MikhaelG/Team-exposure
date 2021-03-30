using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = -1;
    public bool pounce = false;
    public damageplayer damage;
    DashAbility dash;
    public bool invulsecs = false;
    public bool atacking = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        dash = GetComponent<DashAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D edge = Physics2D.Raycast(transform.position, new Vector2(3 * speed, -1), 5, 1); // OBS VIKTIGT MÅSTE VARA PÅ LAGER 1 FÖR ATT FUNGERA kollar i riktningen som fienden rör sig i efter en kant - Gustav
        Debug.DrawRay(transform.position, new Vector3(3 * speed, -1), Color.white);
        if (pounce == false) // ser till att fienden inte vänder sig i luften
        {
            if (edge.collider == null)
            {
                speed = -speed; // om den märker att det finns en kant framför sig så vänder den om - Gustav
            }
        }

        RaycastHit2D groundcheck = Physics2D.Raycast(transform.position, new Vector2(0,-2), 1, 1);
        Debug.DrawRay(transform.position, new Vector2(0, -1), Color.white); 
        if (groundcheck.collider != null && atacking == false)
        {
            pounce = false;
            StopCoroutine(attack());
            StartCoroutine(jumps());// hoppar efter att den når marken -Gustav
        }

        RaycastHit2D playercheck = Physics2D.Raycast(transform.position, new Vector2(5 * speed, 0), 5, 1);
        Debug.DrawRay(transform.position, new Vector3(5 * speed, 0), Color.white);

        if (playercheck.collider != null && pounce == false)
        {
            atacking = true;
            StopCoroutine(jumps());
            StartCoroutine(attack()); //kollar efter spelaren framför fienden. om den uptäcks så hoppar den mot spelaren - Gustav
        }
        
    }
    IEnumerator jumps()
    {
        yield return new WaitForSeconds(1);
        pounce = true;
        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation; // ser till att fienden kan röra på sig - Gustav
        body.velocity = new Vector2(speed, 4);
    }
    IEnumerator attack()
    {
        yield return new WaitForSeconds(1);
        pounce = true;
        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.velocity = new Vector2(speed * 4, 1);
        yield return new WaitForSeconds(1);
        atacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dash = collision.transform.GetComponent<DashAbility>();
            if (dash.DMG == false && invulsecs == false) //Gör att man tar damage när man inte dashar och inte har invul frames. - Daniel
            {
                damage = collision.GetComponent<damageplayer>(); // om fienden kolliderar med spelaren så skapar scriptet en referens till scriptet med health - Gustav
                damage.health--; //här tar spelet bort health från spelaren - Gustav
                print(damage.health);
                invulsecs = true;
                StartCoroutine(invul()); // ser till  att spelaren har möjlighet att undanfly fienden - Gustav
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            body.constraints = RigidbodyConstraints2D.FreezeAll; // ser till att fienden inte faller igenom golvet trots att den är en trigger - Gustav
        }
    }
    IEnumerator invul()
    {
        yield return new WaitForSeconds(2);
        invulsecs = false;
    }
}
