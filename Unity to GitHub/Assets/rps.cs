using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class rps : MonoBehaviour
{
    public VideoClip videoclips;
    public VideoClip rock; //your video will be linked here via inspector
    public VideoClip paper; //your video will be linked here via inspector
    public VideoClip scissor; //your video will be linked here via inspector
    public VideoClip inIdle; //your video will be linked here via inspector
    public VideoPlayer videoplayer;


    public void Awake()
    {
        videoplayer=GetComponent<VideoPlayer>();   
    }
    public void pauseVideo()
    {
        videoplayer.Pause();
    }

    public void playVideo()
    {
        videoplayer.Play();
    }

    public void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
            Debug.Log("over");
            idling();
    }
    public void rockChoice()
    {
        videoplayer.clip = rock;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += CheckOver;
    }

    public void paperChoice()
    {
        videoplayer.clip = paper;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += CheckOver;
    }

    public void scissorChoice()
    {
        videoplayer.clip = scissor;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += CheckOver;
    }

    public void idling()
    {
        videoplayer.isLooping = true;
        videoplayer.clip = inIdle;
    }
}
