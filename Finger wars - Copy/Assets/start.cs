using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class start : MonoBehaviour
{
//-----------------------------[VIDEO PLAYER]----------------------------------// 
    public VideoPlayer videoplayer;
    public CanvasGroup myUIGroup;
    public CanvasGroup startbtncanvasgroup;
    public bool fadeIn = false;
    public bool fadeOut = false;


    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayedstartbtn());
        myUIGroup.alpha = 0;
        startbtncanvasgroup.alpha = 0;
    }

    // Update is called once per frame
    void fixedUpdate()
    {  
        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if (myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                    SceneManager.LoadScene(2);
                }

            }
        }
    }
    public void startbtnvoid()
    {
        SceneManager.LoadScene(2);
        fadeIn = true;
    }
    
    IEnumerator delayedstartbtn()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("delayed message");
        myUIGroup.gameObject.SetActive(false);
        startbtncanvasgroup.alpha = 1;
    }

    




}
