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
        if (Input.GetButtonDown("Dash") && !hasDashed)
        {
            print("Dash");
            hasDashed = true;
            rb.AddForce(new Vector2(DashSpeed, 0));
            rb.velocity = new Vector3(rb.velocity.x, 0);
        }
    }


    private void StopDash()
    {
        //Invoke StopDash, få den att vänta tills dashen ska sluta och stoppa den efter det
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            hasDashed = false;
        }
    }
}

