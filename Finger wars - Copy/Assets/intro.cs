using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class intro : MonoBehaviour
{
//-----------------------------[VIDEO PLAYER]----------------------------------// 
    public VideoClip videoclips;
    public VideoPlayer videoplayer;
//--[INTRO]
    public VideoClip gameintrovideo; //your video will be linked here via inspector
//--[ESCAPE BUTTON]
    public Button gameintroescapeick;
    
    
    public CanvasGroup myUIGroup;
    public bool fadeOut = false;
    public bool fadeIn = false;
    public bool fadenextscene = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myUIGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fadeIn = true;
        }
            if (fadeIn)
            {
                if (myUIGroup.alpha < 1)
                {
                    myUIGroup.alpha += Time.deltaTime;
                    if (myUIGroup.alpha >= 1)
                    {
                        fadeIn = false;
                        SceneManager.LoadScene(1);
                    }

                }
            }



        if(Input.GetKeyDown(KeyCode.S))
        {
            fadeOut = true;
        }
            if (fadeOut)
            {
                if (myUIGroup.alpha >= 0)
                {
                    myUIGroup.alpha -= Time.deltaTime;
                    if (myUIGroup.alpha == 0)
                    {
                        fadeOut = false;
                    }

                }
            }
    }



}
