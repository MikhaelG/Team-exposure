using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float DashSpeed = 500; 
    private Rigidbody2D rb;
    public bool hasDashed = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dash") && !hasDashed) //Kollar om man tyrcker på knappen "Dash" och om hasDashed är false - Daniel
        {
            print("Dash");
            hasDashed = true; //Sätter om hasDashed till true så att man bara kan dasha en gång i luften - Daniel
            rb.AddForce(new Vector2(DashSpeed, 0)); //Lägger till DashSpeed i x axeln så att man åker framåt - Daniel
            rb.velocity = new Vector3(rb.velocity.x, 0); //Gör så att man inte faller ner medans man dashar, tyvärr händer detta bara under frame 1 av dashen - Daniel
        }
    }

    
    private void StopDash()
    {
     //Invoke StopDash, få den att vänta tills dashen ska sluta och stoppa den efter det (Anteckning om vad jag ska lägga till senare) - Daniel
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            hasDashed = false; //Ställer tillbaka hasDashed till false när man nuddar någonting med tag:en "Ground", alltså marken så att man kan använda dashen igen. - Daniel
        }
    }
}

