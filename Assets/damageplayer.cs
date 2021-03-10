using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageplayer : MonoBehaviour
{

    public int health = 5;
    public bool invultime = false;
    private void Update()
    {
        if (health<1)
        {
            Destroy(gameObject);
        }
    }
    
    IEnumerator invulsecs()
    {
        yield return new WaitForSeconds(1);
    }
}
