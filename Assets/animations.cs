using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    public Animator Animator;
    public float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("speed", Input.GetAxis("Horizontal"));


        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
        } else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
        }

        if (direction == -1)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        
    }
}
