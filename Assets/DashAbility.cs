using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float DashSpeed = 100;
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
        if (Input.GetButtonDown("Dash") && !hasDashed) //Kollar om man trycker på Dashknapppen och om hasDashed är false. - Daniel
        {
            print("Dash");
            hasDashed = true; //Ställer om hasDashed till true när man dashar så att man inte kan göra det oändligt. - Daniel
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * DashSpeed, 0)); //Multiplicerar karaktärens horizontal speed med Dashspeed och därmed gör så att man dashar åt det hållet. - Daniel
            rb.velocity = new Vector3(rb.velocity.x, 0); //Fryser karaktärens Y-position så att man inte ska falla neråt under en dash, tyvärr fryser den endast positionen under en frame. - Daniel
        }
    }


    private void StopDash()
    {
        //Invoke StopDash, få den att vänta tills dashen ska sluta och stoppa den efter det (Saker jag (Daniel) ska lägga till senare) - Daniel
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            hasDashed = false; //Ställer tillbaka hasDashed till true när man nuddar marken så att man kan dasha igen. - Daniel
        }
    }
}

