using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class p1wins : MonoBehaviour
{
//-----------------------------[VIDEO PLAYER]----------------------------------// 
    public VideoPlayer videoplayer;
    public CanvasGroup myUIGroup;
    //public CanvasGroup startbtncanvasgroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public GameObject playerwinnerGO;
    public static string playerwinnerstr;

    public AudioSource victorybgm;


    
    // Start is called before the first frame update
    void Start()
    {
        victorybgm.Play();
        myUIGroup.gameObject.SetActive(false);
        myUIGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
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

    void FixedUpdate()
    {
        playerwinnerGO.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = playerwinnerstr + " Wins!";   
    }
    public void playagainbtn()
    {
        SceneManager.LoadScene(2);
        fadeIn = true;
    }
    public void exitbtn()
    {
        myUIGroup.gameObject.SetActive(true);
        fadeIn = true;
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        
    }

    




}
