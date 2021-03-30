using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class damageplayer : MonoBehaviour
{

    public int health = 5;
    public bool invultime = false;
    public Text healthcount;
    private void Update() 
    {
        if (health<1)
        {
            SceneManager.LoadScene("level"); //spelaren startar om när dens liv blir under noll - Gustav
        }
        healthcount.text = "health:" + health; // updaterar ui med health - Gustav
    }
}
