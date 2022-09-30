using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;


public class nameinput : MonoBehaviour
{
    public TMP_InputField p1inputname;
    public TMP_InputField p1inputhealth;
    public string p1inputnametemp;
    public Button fullhealth;
    public Button readybtn;
    public int p1inputname_converted_to_int;

    public int p1health;



    public TMP_InputField p2inputname;
    public TMP_InputField p2inputhealth;
    public string p2inputnametemp;
    public Button p2fullhealth;
    public Button p2readybtn;
    public int p2inputname_converted_to_int;

    public int p2health;




    public GameObject bgm;






    public VideoPlayer videoplayer;
//--[INTRO]
    public CanvasGroup myUIGroup;
    public bool fadeOut = false;
    public bool fadeIn = false;


    public void Awake()//[Videoplayer]
    {
        videoplayer=GetComponent<VideoPlayer>();
    }

    void Start()
    {
        myUIGroup.alpha = 1;
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
    
    public void fullheathbtn()
    {
        //p1inputhealth.TMP_InputField.GetComponent<TMP_InputField>().text = "100";
        p1inputhealth.text = "100";
    }

    public void p2fullheathbtn()
    {
        //p1inputhealth.TMP_InputField.GetComponent<TMP_InputField>().text = "100";
        p2inputhealth.text = "100";
    }

    public void ready()
    {
        p1inputname_converted_to_int = p1health;
        p1inputnametemp = p1inputhealth.text;
        int.TryParse(p1inputnametemp, out p1inputname_converted_to_int);
        video.p1namestr = p1inputname.text;
        video.p1hp = p1inputname_converted_to_int;
        SceneManager.LoadScene(4);
    }

    public void p2ready()
    {
        p2inputname_converted_to_int = p2health;
        p2inputnametemp = p2inputhealth.text;
        int.TryParse(p2inputnametemp, out p2inputname_converted_to_int);
        video.p2namestr = p2inputname.text;
        video.p2hp = p2inputname_converted_to_int;
        Destroy(bgm);
        SceneManager.LoadScene(5);
    }

}
