using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    Character2DController move;
    public float DashSpeed = 100;
    private Rigidbody2D rb;
    public bool hasDashed = false;
    public bool DMG = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<Character2DController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Dash") && !hasDashed) //Kollar om man trycker på Dashknapppen och om hasDashed är false. - Daniel
        {
            print("Dash");
            hasDashed = true; //Ställer om hasDashed till true när man dashar så att man inte kan göra det oändligt. - Daniel
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * DashSpeed, 0)); //Multiplicerar karaktärens horizontal speed med Dashspeed och därmed gör så att man dashar åt det hållet. - Daniel
            rb.velocity = new Vector3(rb.velocity.x, 0); //Fryser karaktärens Y-position så att man inte ska falla neråt under en dash, tyvärr fryser den endast positionen under en frame. - Daniel       }
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; //Fryser karaktärens Y-position och rotationen när den dashar. - Daniel
            Invoke("StopDash", 1); //Väntar 1 sekdund och aktiverar StopDash. - Daniel
            move.MoveAccess = false; //Ställer om MoveAccess från Character2DController till false. På så sätt kan man inte öka eller bromsa sin hastighet under en dash. - Daniel
            DMG = true;
        }
    }
    void StopDash()
    {
        rb.constraints = RigidbodyConstraints2D.None; //Tar bort alla constraints Rigidbody:n har under en dash. - Daniel
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; //Fryzer rotationen så att karaktären inte faller ihop. - Daniel
        rb.velocity = new Vector2(0, 0); //Ställer tillbaka hastigheten man har efter dashen tar slut. På så sätt behåller man inte massvis med hastighet när dashen tar slut. - Daniel
        move.MoveAccess = true; //Ställer tillbaka MoveAccess till true så att man kan hoppa och gå efter dashen tar slut. - Daniel
        DMG = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            hasDashed = false; //Ställer tillbaka hasDashed till true när man nuddar marken så att man kan dasha igen. - Daniel
        }

        if (collision.gameObject.CompareTag("Enemy") && DMG == true)
        {
            Destroy(collision.gameObject);
        }
    }
}

