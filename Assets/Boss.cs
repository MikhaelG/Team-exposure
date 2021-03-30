using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int BossHP;
    public damageplayer damage;
    // Start is called before the first frame update
    void Start()
    {
        BossHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossHP <1)
        {
            SceneManager.LoadScene("menu");
        }
    }
}
