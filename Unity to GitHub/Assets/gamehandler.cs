using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class gamehandler : MonoBehaviour
{
    
    public VideoClip videoclips;
    public VideoClip vid2;
    public VideoPlayer videoplayer;
    //public int videoClipIndex;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

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

    public void nextVideo()
    {
        videoplayer.clip = vid2;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }


}
