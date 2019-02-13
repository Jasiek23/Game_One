using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthly : MonoBehaviour
{
    public float health = 100.0f;//healthly full

    public void inflictedDamage(float mat)
    {
        health -= mat;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public bool ifDead()
    {
        if(health<=0)
        {
            return true;
        }
        return false;
    }

}
