using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class battlebgm : MonoBehaviour
{
    public static battlebgm instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}