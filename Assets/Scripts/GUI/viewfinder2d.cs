using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewfinder2d : MonoBehaviour
{
    public Texture2D viewfinder;

    public Rect position; // position of viewfinder

    public bool show = true;

    void Start()
    {
        position = new Rect((Screen.width - viewfinder.width) / 2, (Screen.height - viewfinder.height) / 2, viewfinder.width, viewfinder.height);
        
    }

    void OnGUI()
    {
        if(show == true)
        {
            GUI.DrawTexture(position, viewfinder);
        }
    }
}
