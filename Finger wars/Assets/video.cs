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

//--[P1 MISS]
    public VideoClip p1lowkickmiss; //your video will be linked here via inspector
    public VideoClip p1highkickmiss; //your video will be linked here via inspector
    public VideoClip p1ultimiss; //your video will be linked here via inspector

//--[P1 CINE]   
    public VideoClip p1lowkickhitcine;
    public VideoClip p1highkickhitcine;
    public VideoClip p1ultihitcine;


//[PLAYER 2 VIDEOS]
//--[P2 HIT]
    public VideoClip p2lowkickhit; //your video will be linked here via inspector
    public VideoClip p2highkickhit; //your video will be linked here via inspector
    public VideoClip p2ulti; //your video will be linked here via inspector

//--[P2 MISS]
    public VideoClip p2lowkickmiss; //your video will be linked here via inspector
    public VideoClip p2highkickmiss; //your video will be linked here via inspector
    public VideoClip p2ultimiss; //your video will be linked here via inspector

//--[P2 CINE]
    public VideoClip  p2lowkickhitcine;
    public VideoClip  p2highkickhitcine;
    public VideoClip  p2ulticine;


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
    public static int p1hp;

    public static string p1namestr;
    public GameObject p1name;

//[PLAYER 2 HEALTH]

    public GameObject p2healthGO;
    public static int p2hp;
    
    public static string p2namestr;
    public GameObject p2name;
//---------------------------------------------------------------------------------------
   
   
   
//-----------------------------[CONSTANT CHANGING]----------------------------------// 
 
    public int globalaccuracy;
    public bool turn = false;

    //public AudioSource battlebgm;
    public AudioSource lowhealthbgm;
    public AudioSource kickhitsfx;
    public AudioSource killingcinesfx;
    public float setdelaytime;

    public bool battletolowhealthbgm = false;
    public bool someonewontoggle = false;

    public bool p1cinemode = false;
    public bool p2cinemode = false;
    public bool p1nomoreulti = false;
    public bool p2nomoreulti = false;


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
                if (p2hp <= 0)
                {
                    endgamefader();
                    p1cinemode = true;
                    
                }
            }
            else if (turn == true)//[Damages P1 when P2 turn]
            {
            p1hp = currenthp -= damageAmount;
                if (p1hp <= 0)
                {
                    endgamefader();
                    p2cinemode = true;
                    
                }
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
            if (someonewontoggle == true)
            {
            if (p2hp <= 0)
            {
                delayedendgame();
            }

            if (p1hp <= 0)
            {
                delayedendgame();
            }
            }
    }
//---------------------------------------------------------------------------------------

//-----------------------------[ENDED GAME CHECK]----------------------------------// 

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
        else if (fadeIn == true)
        {
            myUIGroup.gameObject.SetActive(true);
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if (myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
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
        if (someonewontoggle == false)
        {
            if (p1hp <= 0)
            {
                Debug.Log("someone won");
                playerwinner = "player2";
                someonewontoggle = true;
                
            }
            else if (p2hp <= 0)
            {
                Debug.Log("someone won");
                playerwinner = "player1";
                someonewontoggle = true;
                
            }
        }
        if (p1nomoreulti == true)
        {
            btnp1ulti.interactable = false;
        }

        if (p2nomoreulti == true)
        {
            btnp2ulti.interactable = false;
        }

    }
    public void Awake()//[Videoplayer]
    {
        videoplayer=GetComponent<VideoPlayer>();
        p1name.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = p1namestr;
        p2name.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = p2namestr;

        fadeOut = true;

    }



//-----------------------------[PLAYER 1 ATTACK]----------------------------------// 
//---------------[P1-LOWKICK]
//--[P1LK-MISS]

    public void p1lowkickhitvoid()
    {
        
        dealDamage(p2hp, 6, 65);// damage & accuracy
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
            if (p1cinemode == false) //normal
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

            else if (p1cinemode == true) //cine lowkick
            {
            killingcinesfx.Play();
            setdelaytime = 0.2f;
            delayedsfx();
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1lowkickhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowkick hit CINE");
            videoplayer.loopPointReached += checkOver;
            }
        }
    }
//------------------------


//---------------[P1-HIGHKICK]
//--[P1HK-MISS]

    public void p1highkickhitvoid()
    {
        dealDamage(p2hp, 12, 45);// damage & accuracy
        if (globalaccuracy > 45)
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
        else if (globalaccuracy <= 45)
        {
            if (p1cinemode == false) //normal
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

            else if (p1cinemode == true) //cine highkick
            {
            delayedsfx();
            btnp1lowkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1highkickhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: highkick hit CINE");
            }
        }
    }
//------------------------

//---------------[P1-ULTI]
//--[P1ULTI-MISS]
    public void p1ultivoid()
    {
        dealDamage(p2hp, 25, 90);// damage & accuracy
        if (globalaccuracy > 90)
        {
        btnp1lowkick.interactable = false;
        btnp1highkick.interactable = false;
        videoplayer.clip = p1ultimiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: ulti missed");
        p1nomoreulti = true;

        }

//--[P1ULTI-HIT]
        else if (globalaccuracy <= 90)
        {
            if (p1cinemode == false)
            {
            btnp1lowkick.interactable = false;
            btnp1highkick.interactable = false;
            videoplayer.clip = p1ulti;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = true;
            turnChecker();
            Debug.Log("player1: ulti succeed");
            p1nomoreulti = true;
            }

            else if (p1cinemode == true)
            {
            btnp1lowkick.interactable = false;
            btnp1highkick.interactable = false;
            videoplayer.clip = p1ultihitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: ulti succeed");
            p1nomoreulti = true;
            }
        }
    }
//------------------------
//-----------------------------------------------------------------------


//-----------------------------[PLAYER 2 ATTACK]----------------------------------// 
//---------------[P2-LOWKICK]
//--[P2LK-MISS]
    public void p2lowkickhitvoid()
    {
        dealDamage(p1hp, 6, 65);// damage & accuracy
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
            if (p2cinemode == false)
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

            else if (p2cinemode == true)
            {
            setdelaytime = 0.2f;
            delayedsfx();
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p2lowkickhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowkick hit CINE");
            }
        }
    }
//------------------------

//---------------[P2-HIGHKICK]
//--[P2HK-MISS]
    public void p2highkickhitvoid()
    {
        dealDamage(p1hp, 12, 45);// damage & accuracy
        if (globalaccuracy > 45)
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

//--[P2HK-HIT]

        else if (globalaccuracy <= 45)
        {

            if (p2cinemode == false)
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

            else if (p2cinemode == true)
            {
            setdelaytime = 0.2f;
            delayedsfx();
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p2highkickhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowkick hit CINE");
            }
        }
    }
//------------------------

//---------------[P2-ULTI]
//--[P2ULTI-MISS]
   
    public void p2ultivoid()
    {
        dealDamage(p1hp, 25, 90);// damage & accuracy
        if (globalaccuracy > 90)
        {
        btnp2lowkick.interactable = false;
        btnp2highkick.interactable = false;
        videoplayer.clip = p2ultimiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: ulti missed");
        p2nomoreulti = true;
        }

//--[P2ULTI-HIT]
        else if (globalaccuracy <= 90)
        {
            if (p2cinemode == false)
            {
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            videoplayer.clip = p2ulti;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = false;
            turnChecker();
            Debug.Log("player2: ulti succeed");
            p2nomoreulti = true;
            }

            else if (p2cinemode == true)
            {
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            videoplayer.clip = p2ulticine;
            videoplayer.isLooping = false;
            Debug.Log("player2: ulti succeed");
            p2nomoreulti = true;    
            }
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

    public void delayedendgame()
    {
    StartCoroutine(delayedendgameIE());
    delayedendgameIE();
    }

    public string playerwinner;
    IEnumerator delayedendgameIE()
    {
        yield return new WaitForSeconds(2f);
        if (playerwinner == "player1")
        {
            Debug.Log("p1wins");
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene(3);
        }
        else if (playerwinner == "player2")
        {
            Debug.Log("p2wins");
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene(3);
        }   
    }


    public void endgamefader()
    {
        StartCoroutine(endgamefaderIE());
        endgamefaderIE();
    }

    IEnumerator endgamefaderIE()
    {
        yield return new WaitForSeconds(2f);
        fadeIn = true;
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