using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = -3;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D edgeleft = Physics2D.Raycast(transform.position, new Vector2(-2, -2), 5, 1); // OBS VIKTIGT MÅSTE VARA PÅ LAGER 1 FÖR ATT FUNGERA
        RaycastHit2D edgeright = Physics2D.Raycast(transform.position, new Vector2(2, -2), 5, 1);
        Debug.DrawRay(transform.position, new Vector2(-2, -2), Color.white);
        if (edgeleft.collider == null || edgeright.collider == null)
        {
            speed = -speed;
        } 
        body.velocity = new Vector2(speed, body.velocity.y);
    }
}
