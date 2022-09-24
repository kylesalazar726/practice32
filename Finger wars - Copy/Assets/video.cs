using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    private const bool V = true;

    //-----------------------------[VIDEO PLAYER]----------------------------------// 
    public VideoClip videoclips;
    public VideoPlayer videoplayer;

//-----------------------------[RECOGNIZING VIDEO CLIP]----------------------------------// 

//--[IDLE]
    public VideoClip inIdle; //your video will be linked here via inspector

//[PLAYER 1 VIDEOS]
//--[P1 HIT]
    public VideoClip p1lowkickhit; //your video will be linked here via inspector
    public VideoClip p1highkickhit; //your video will be linked here via inspector
    public VideoClip p1ulti; //your video will be linked here via inspector
    public VideoClip p1ultimiss; //your video will be linked here via inspector


//--[P1 MISS]
    public VideoClip p1lowkickmiss; //your video will be linked here via inspector
    public VideoClip p1highkickmiss; //your video will be linked here via inspector


//[PLAYER 2 VIDEOS]
//--[P2 HIT]
    public VideoClip p2lowkickhit; //your video will be linked here via inspector
    public VideoClip p2highkickhit; //your video will be linked here via inspector
    public VideoClip p2ulti; //your video will be linked here via inspector
    public VideoClip p2ultimiss; //your video will be linked here via inspector

//--[P2 MISS]
    public VideoClip p2lowkickmiss; //your video will be linked here via inspector
    public VideoClip p2highkickmiss; //your video will be linked here via inspector

//---------------------------------------------------------------------------------------


//-----------------------------[RECOGNIZING BUTTONS]----------------------------------// 
//[PLAYER 1 BUTTONS]
    public Button btnp1lowkick;
    public Button btnp1highkick;
    public Button btnp1ulti;

//[PLAYER 2 BUTTONS]
    public Button btnp2lowkick;
    public Button btnp2highkick;
    public Button btnp2ulti;

//---------------------------------------------------------------------------------------
 
 
 //-----------------------[RECOGNIZING HEALTH TEXT & HP ints]-----------------------------// 

//[PLAYER 1 HEALTH]
    public GameObject p1healthGO;
    public int p1hp = 100;

//[PLAYER 2 HEALTH]

    public GameObject p2healthGO;
    public int p2hp = 100;
    
//---------------------------------------------------------------------------------------
   
   
   
//-----------------------------[CONSTANT CHANGING]----------------------------------// 
 
    public int globalaccuracy;
    public bool turn = false;

    //public AudioSource battlebgm;
    public AudioSource lowhealthbgm;
    public AudioSource kickhitsfx;
    public float setdelaytime;

    public bool battletolowhealthbgm = false;
//---------------------------------------------------------------------------------------

//-----------------------------[FADE IN & OUT]----------------------------------// 
    public CanvasGroup myUIGroup;
    public bool fadeOut = false;
    public bool fadeIn = false;
    public bool fadenextscene = false;
//---------------------------------------------------------------------------------------


//-----------------------------[IMPORTANT VOIDS]----------------------------------// 
//-----------------------------[IMPORTANT VOIDS]----------------------------------//
//-----------------------------[IMPORTANT VOIDS]----------------------------------//

//-----------------------------[DAMAGING LOGIC]----------------------------------// 
    void dealDamage(int currenthp, int damageAmount, int accuracy)//[Damager]
    {
        int ran = Random.Range(0, 101);
        globalaccuracy = ran;
        if(ran <= accuracy)
        {
            if (turn == false)//[Damages P2 when P1 turn]
            {
            p2hp = currenthp -= damageAmount;
            }
            else if (turn == true)//[Damages P1 when P2 turn]
            {
            p1hp = currenthp -= damageAmount;
            }        
        
        }
    }
//---------------------------------------------------------------------------------------


//-----------------------------[TURN CHECK]----------------------------------// 

    public void turnChecker()//[false = player1turn, true = player2turn]
    {
        if (turn == false)//[Disables all player 2 buttons]
        {
            btnp1lowkick.interactable = true;
            btnp1highkick.interactable = true;
            btnp1ulti.interactable = true;
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            btnp2ulti.interactable = false;
        }
        else if (turn == true)//[Disables all player 1 buttons]
        {
            btnp1lowkick.interactable = false;
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            btnp2lowkick.interactable = true;
            btnp2highkick.interactable = true;
            btnp2ulti.interactable = true;
        }
    }
//---------------------------------------------------------------------------------------

//-----------------------------[ENDED VIDEO CHECK]----------------------------------// 

    public void checkOver(UnityEngine.Video.VideoPlayer vp)//[Checks if the video is already done]
    {
            idling();//[redirects to idling state if video is done]
    }
//---------------------------------------------------------------------------------------

//-----------------------------[IDLE STATES]----------------------------------// 
    public void idling()
    {
        if (turn == true)
        {
        videoplayer.isLooping = true;
        videoplayer.clip = inIdle;
        }
        else if (turn == false)
        {
        videoplayer.isLooping = true;
        videoplayer.clip = inIdle;
        }
    }
    public void idling1()
    {
        videoplayer.isLooping = true;
        videoplayer.clip = inIdle;
        turn = false;
    }
//---------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------



//------[BODY]--------[BODY]-------[BODY]--------[BODY]-------[BODY]-------[BODY]----------[BODY]----------//

    void Start()//[player 1 first, then player 2]
    {

        btnp1lowkick.interactable = true;
        btnp1highkick.interactable = true;
        btnp1ulti.interactable = true;
        btnp2lowkick.interactable = false;
        btnp2highkick.interactable = false;
        btnp2ulti.interactable = false;

        myUIGroup.alpha = 1;
    }
    
    void Update()//[constant updating healths of player 1&2]
    {
        p2healthGO.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = p2hp + "";    
        p1healthGO.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = p1hp + "";

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

    void FixedUpdate()
    {
        if (battletolowhealthbgm == false)
        {
            if (p1hp <= 30)
            {
                    Debug.Log("battletohealthbgm");
                    battlebgm.instance.GetComponent<AudioSource>().Pause();
                    //battlebgm.instance.GetComponent<AudioSource>().Play();
                    lowhealthbgm.Play();
                    battletolowhealthbgm = true;
            }
            else if (p2hp <= 30)
            {
                    Debug.Log("battletohealthbgm");
                    battlebgm.instance.GetComponent<AudioSource>().Pause();
                    //battlebgm.instance.GetComponent<AudioSource>().Play();
                    lowhealthbgm.Play();
                    battletolowhealthbgm = true;
            }
        }
    }
    public void Awake()//[Videoplayer]
    {
        videoplayer=GetComponent<VideoPlayer>();
    }



//-----------------------------[PLAYER 1 ATTACK]----------------------------------// 
//---------------[P1-LOWKICK]
//--[P1LK-MISS]

    public void p1lowkickhitvoid()
    {
        
        dealDamage(p2hp, 10, 65);// damage & accuracy
        if (globalaccuracy > 65)
        {
        btnp1highkick.interactable = false;
        btnp1ulti.interactable = false;
        videoplayer.clip = p1lowkickmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: lowkick missed");
        }

//--[P1LK-HIT]
        else if (globalaccuracy <= 65)
        {
        setdelaytime = 0.2f;
        delayedsfx();
        btnp1highkick.interactable = false;
        btnp1ulti.interactable = false;
        videoplayer.clip = p1lowkickhit;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: lowkick hit");
        }
    }
//------------------------


//---------------[P1-HIGHKICK]
//--[P1HK-MISS]

    public void p1highkickhitvoid()
    {
        dealDamage(p2hp, 15, 50);// damage & accuracy
        if (globalaccuracy > 50)
        {
        btnp1lowkick.interactable = false;
        btnp1ulti.interactable = false;
        videoplayer.clip = p1highkickmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: highkick missed");
        }

//--[P1HK-HIT]
        else if (globalaccuracy <= 50)
        {
        kickhitsfx.Play();
        btnp1lowkick.interactable = false;
        btnp1ulti.interactable = false;
        videoplayer.clip = p1highkickhit;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: highkick succeed");
        }
    }
//------------------------

//---------------[P1-ULTI]
//--[P1ULTI-MISS]
    public void p1ultivoid()
    {
        dealDamage(p2hp, 35, 25);// damage & accuracy
        if (globalaccuracy > 25)
        {
        btnp1lowkick.interactable = false;
        btnp1highkick.interactable = false;
        videoplayer.clip = p1ultimiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: ulti missed");
        }

//--[P1ULTI-HIT]
        else if (globalaccuracy <= 25)
        {
        btnp1lowkick.interactable = false;
        btnp1highkick.interactable = false;
        videoplayer.clip = p1ulti;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: ulti succeed");
        }
    }
//------------------------
//-----------------------------------------------------------------------


//-----------------------------[PLAYER 2 ATTACK]----------------------------------// 
//---------------[P2-LOWKICK]
//--[P2LK-MISS]
    public void p2lowkickhitvoid()
    {
        dealDamage(p1hp, 10, 65);// damage & accuracy
        if (globalaccuracy > 65)
        {
        btnp2highkick.interactable = false;
        btnp2ulti.interactable = false;
        videoplayer.clip = p2lowkickmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: lowkick missed");
        }

//--[P2LK-HIT]

        else if (globalaccuracy <= 65)
        {
        setdelaytime = 0.5f;
        delayedsfx();
        btnp2highkick.interactable = false;
        btnp2ulti.interactable = false;
        videoplayer.clip = p2lowkickhit;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: lowkick hit");
        }
    }
//------------------------

//---------------[P2-HIGHKICK]
//--[P2LK-MISS]
    public void p2highkickhitvoid()
    {
        dealDamage(p1hp, 15, 50);// damage & accuracy
        if (globalaccuracy > 50)
        {
        btnp2lowkick.interactable = false;
        btnp2ulti.interactable = false;
        videoplayer.clip = p2highkickmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: highkick missed");
        }

//--[P2LK-HIT]

        else if (globalaccuracy <= 50)
        {
        kickhitsfx.Play();
        btnp2lowkick.interactable = false;
        btnp2ulti.interactable = false;
        videoplayer.clip = p2highkickhit;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: highkick hit");
        }
    }
//------------------------

//---------------[P2-ULTI]
//--[P2ULTI-MISS]
   
    public void p2ultivoid()
    {
        dealDamage(p1hp, 35, 25);// damage & accuracy
        if (globalaccuracy > 25)
        {
        btnp2lowkick.interactable = false;
        btnp2highkick.interactable = false;
        videoplayer.clip = p2ultimiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: ulti missed");
        }

//--[P2ULTI-HIT]
        else if (globalaccuracy <= 25)
        {
        btnp2lowkick.interactable = false;
        btnp2highkick.interactable = false;
        videoplayer.clip = p2ulti;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: ulti succeed");
        }
    }
//------------------------



    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void delayedsfx()
    {
    StartCoroutine(delayedsfxIE());
    delayedsfxIE();
    }

    IEnumerator delayedsfxIE()
    {
        yield return new WaitForSeconds(setdelaytime);
        kickhitsfx.Play();
    }


}






//-----------------------------[UNUSED BUT IMPORTANT]----------------------------------// 
// 
//    public void pauseVideo()
//    {
//        videoplayer.Pause();
//    }
//
//    public void playVideo()
//    {
//        videoplayer.Play();
//    }
//---------------------------------------------------------------------------------------