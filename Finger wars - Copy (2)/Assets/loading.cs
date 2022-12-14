using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class loading : MonoBehaviour
{
//-----------------------------[VIDEO PLAYER]----------------------------------// 
    public VideoPlayer videoplayer;
//--[INTRO]
    public CanvasGroup myUIGroup;
    public bool fadeOut = false;
    public bool fadeIn = false;

    public void checkOver(UnityEngine.Video.VideoPlayer vp)//[Checks if the video is already done]
    {
        nextvid();
    }
    public void nextvid()
    {
        SceneManager.LoadScene(3);
    }

    public void Awake()//[Videoplayer]
    {
        videoplayer=GetComponent<VideoPlayer>();
    }

    void Start()
    {
        myUIGroup.alpha = 1;
        videoplayer.loopPointReached += checkOver;
    }
    void Update()
    {
        
        fadeOut = true;
        if (fadeOut)
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                    myUIGroup.gameObject.SetActive(false);
                }

             }
        }
    }

}
