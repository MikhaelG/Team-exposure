using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos; //samma som i checkpoint scriptet - Mikhael
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))   //Respawna manuellt till sista checkpoint med left ctrl - Mikhael
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }
}
