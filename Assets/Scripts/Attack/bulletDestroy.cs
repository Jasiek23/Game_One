using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
    public float duration = 1f;

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;

        if(duration <=0)
        {
            Destroy(gameObject);
        }
    }
}
