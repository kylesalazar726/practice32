using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class nameinputbgm : MonoBehaviour
{
    public static nameinputbgm instance;
 
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
