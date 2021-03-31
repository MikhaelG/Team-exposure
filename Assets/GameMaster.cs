using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector2 lastCheckPointPos;
    public Vector2 startingposition;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
 
    }

    public void resetcheckpoint()
    {
        lastCheckPointPos = startingposition; //gör så att man spawnas i början och inte i sista checkpointen - Mikhael
    } 

}
