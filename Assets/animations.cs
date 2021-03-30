using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    public Animator Animator;
    public float direction = 1;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("speed", Input.GetAxis("Horizontal")); // ser till att animationer spelas när spelaren går - Gustav


        if (Input.GetAxis("Horizontal") < 0) 
        {
            direction = -1;
        } else if (Input.GetAxis("Horizontal") > 0) // lagrar vilken riktning som spelaren senast gick i för att se till att den är vänd i rätt riktning - Gustav
        {
            direction = 1;
        }

        if (direction == -1)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1); // vänder spelaren i lämplig rikttning utifrån riktningen som den senast gick mot - Gustav
        } else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump")) // startar animationen för att hoppa - Gustav
        {
            Animator.SetFloat("jump", 1);
        } else if (rb.velocity.y < 0.01)
        {
            Animator.SetFloat("jump", rb.velocity.y);
        }
    }
}
