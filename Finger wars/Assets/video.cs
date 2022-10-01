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
    public VideoClip p1lowpunchhit;
    public VideoClip p1highpunchhit;
    public VideoClip p1lowkickhit; //your video will be linked here via inspector
    public VideoClip p1highkickhit; //your video will be linked here via inspector
    public VideoClip p1ulti; //your video will be linked here via inspector

//--[P1 MISS]
    public VideoClip p1lowpunchmiss;
    public VideoClip p1highpunchmiss;
    public VideoClip p1lowkickmiss; //your video will be linked here via inspector
    public VideoClip p1highkickmiss; //your video will be linked here via inspector
    public VideoClip p1ultimiss; //your video will be linked here via inspector

//--[P1 CINE]   
    public VideoClip p1lowpunchhitcine;
    public VideoClip p1highpunchhitcine;
    public VideoClip p1lowkickhitcine;
    public VideoClip p1highkickhitcine;
    public VideoClip p1ultihitcine;


//[PLAYER 2 VIDEOS]
//--[P2 HIT]
    public VideoClip p2lowpunchhit;
    public VideoClip p2highpunchhit;
    public VideoClip p2lowkickhit; //your video will be linked here via inspector
    public VideoClip p2highkickhit; //your video will be linked here via inspector
    public VideoClip p2ulti; //your video will be linked here via inspector

//--[P2 MISS]
    public VideoClip p2lowpunchmiss;
    public VideoClip p2highpunchmiss;
    public VideoClip p2lowkickmiss; //your video will be linked here via inspector
    public VideoClip p2highkickmiss; //your video will be linked here via inspector
    public VideoClip p2ultimiss; //your video will be linked here via inspector

//--[P2 CINE]
    public VideoClip p2lowpunchhitcine;
    public VideoClip p2highpunchhitcine;
    public VideoClip p2lowkickhitcine;
    public VideoClip p2highkickhitcine;
    public VideoClip p2ulticine;

    public VideoClip entrance;


//---------------------------------------------------------------------------------------


//-----------------------------[RECOGNIZING BUTTONS]----------------------------------// 
//[PLAYER 1 BUTTONS]
    public Button btnp1lowpunch;
    public Button btnp1highpunch;
    public Button btnp1lowkick;
    public Button btnp1highkick;
    public Button btnp1ulti;

//[PLAYER 2 BUTTONS]
    public Button btnp2lowpunch;
    public Button btnp2highpunch;
    public Button btnp2lowkick;
    public Button btnp2highkick;
    public Button btnp2ulti;

//---------------------------------------------------------------------------------------
 
 
 //-----------------------[RECOGNIZING HEALTH TEXT & HP ints]-----------------------------// 

//[PLAYER 1 HEALTH]
    public GameObject p1healthGO;
    public static int p1hp = 100;

    public static string p1namestr = "p1";
    public GameObject p1name;

//[PLAYER 2 HEALTH]

    public GameObject p2healthGO;
    public static int p2hp = 100;
    
    public static string p2namestr = "p2";
    public GameObject p2name;
//---------------------------------------------------------------------------------------
   
   
   
//-----------------------------[CONSTANT CHANGING]----------------------------------// 
 
    public int globalaccuracy;
    public bool turn = false;

    //public AudioSource battlebgm;
    public AudioSource lowhealthbgm;
    public AudioSource kickhitsfx;


    public AudioSource punchsfx1;
    public AudioSource punchsfx2;
    public AudioSource punchsfx3;

    public AudioSource kicksfx1;
    public AudioSource kicksfx2;
    public AudioSource kicksfx3;



    public AudioSource killingcinesfx;
    public float setdelaytime;

    public bool battletolowhealthbgm = false;
    public bool someonewontoggle = false;

    public bool p1cinemode = false;
    public bool p2cinemode = false;
    public bool p1nomoreulti = false;
    public bool p2nomoreulti = false;
//---------------------------------------------------------------------------------------



//-----------------------------[SPEECH]----------------------------------// 

    public AudioSource p1speech1;
    public AudioSource p1speech2;
    public AudioSource p1speech3;
    public AudioSource p1ultispeech;

    public AudioSource p2speech1;
    public AudioSource p2speech2;
    public AudioSource p2speech3;
    public AudioSource p2ultispeech;


    public bool waitforspeech = false;

    public void waitforspeechdelay()
    {
        StartCoroutine(waitforspeechdelayIE());
    }

    IEnumerator waitforspeechdelayIE()
    {
        waitforspeech = true;
        playerspeech();
        yield return new WaitForSeconds(5f);
        waitforspeech = false;
    }


    public bool enable_pauseallspeech = false;
    public void pauseallspeech()
    {
        p1speech1.Pause();
        p1speech2.Pause();
        p1speech3.Pause();
        p2speech1.Pause();
        p2speech2.Pause();
        p2speech3.Pause();
    }



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
            btnp1lowpunch.interactable = true;
            btnp1highpunch.interactable = true;
            btnp1lowkick.interactable = true;
            btnp1highkick.interactable = true;
            btnp1ulti.interactable = true;
            btnp2lowpunch.interactable = false;
            btnp2highpunch.interactable = false;
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            btnp2ulti.interactable = false;
        }
        else if (turn == true)//[Disables all player 1 buttons]
        {
            btnp1lowpunch.interactable = false;
            btnp1highpunch.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            btnp2lowpunch.interactable = true;
            btnp2highpunch.interactable = true;
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
        waitforentrancetoend();
        entrancereturntoloop();
        videoplayer.clip = entrance;
        videoplayer.isLooping = false;

        btnp1lowpunch.interactable = true;
        btnp1highpunch.interactable = true;
        btnp1lowkick.interactable = true;
        btnp1highkick.interactable = true;
        btnp1ulti.interactable = true;

        btnp2lowpunch.interactable = false;
        btnp2highpunch.interactable = false;
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
            if (p1hp <= 20)
            {
                    Debug.Log("battletohealthbgm");
                    battlebgm.instance.GetComponent<AudioSource>().Pause();
                    //battlebgm.instance.GetComponent<AudioSource>().Play();
                    lowhealthbgm.Play();
                    battletolowhealthbgm = true;
            }
            else if (p2hp <= 20)
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


        if (doneentrance == true)
        {
            if (waitforspeech == false)
            {
            waitforspeechdelay();
            }
        }


        if (enable_pauseallspeech == true)
        {
            pauseallspeech();
        }


    }

    public bool doneentrance = false;
    public void playerspeech()
    {
    int speechran = Random.Range(1, 6);
        if (speechran == 1)
        {  
            p2speech1.Play();
        }
        else if (speechran == 2)
        {  
            p2speech2.Play();
        }
        else if (speechran == 3)
        {  
            p2speech3.Play();
        }

        else if (speechran == 4)
        {  
            p1speech1.Play();
        }
        else if (speechran == 5)
        {  
            p1speech2.Play();
        }
        else if (speechran == 6)
        {  
            p1speech3.Play();
        }
    }


    public void waitforentrancetoend()
    {
        StartCoroutine(waitforentrancetoendIE());
    }

    IEnumerator waitforentrancetoendIE()
    {
        yield return new WaitForSeconds(14f);
        doneentrance = true;
    }



    public void Awake()//[Videoplayer]
    {
        videoplayer=GetComponent<VideoPlayer>();
        p1name.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = p1namestr;
        p2name.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = p2namestr;

        fadeOut = true;

    }


    public void entrancereturntoloop()
    {
        StartCoroutine(entrancereturntoloopIE());
    }

    IEnumerator entrancereturntoloopIE()
    {
        yield return new WaitForSeconds(14f);
        videoplayer.isLooping = true;
        idling();

    }


//-----------------------------[PLAYER 1 ATTACK]----------------------------------// 





//---------------[P1-LOWPUNCH]
//--[P1LP-MISS]

    public void p1lowpunchhitvoid()
    {
        
        dealDamage(p2hp, 3, 75);// damage & accuracy
        if (globalaccuracy > 75)
        {
        btnp1highpunch.interactable = false;
        btnp1highkick.interactable = false;
        btnp1lowkick.interactable = false;
        btnp1ulti.interactable = false;
        videoplayer.clip = p1lowpunchmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: lowpunch missed");
        }

//--[P1LP-HIT]
        else if (globalaccuracy <= 75)
        {
            if (p1cinemode == false) //normal
            {
            setdelaytime = 1f;
            delayedsfxpunch();
            setdelaytime = 1.3f;
            delayedsfxpunch();
            btnp1highpunch.interactable = false;
            btnp1highkick.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1lowpunchhit;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = true;
            turnChecker();
            Debug.Log("player1: lowpunch hit");
            }

//--[P1LPCINE-HIT]
            else if (p1cinemode == true) //cine lowpunch
            {
            killingcinesfx.Play();
            setdelaytime = 1f;
            delayedsfxpunch();
            setdelaytime = 1.3f;
            delayedsfxpunch();
            btnp1highpunch.interactable = false;
            btnp1highkick.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1lowpunchhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowpunch hit CINE");
            //videoplayer.loopPointReached += checkOver;
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
            }
        }
    }
//------------------------



//---------------[P1-HIGHPUNCH]
//--[P1HP-MISS]

    public void p1highpunchhitvoid()
    {
        dealDamage(p2hp, 8, 55);// damage & accuracy
        if (globalaccuracy > 55)
        {
        btnp1lowpunch.interactable = false;
        btnp1lowkick.interactable = false;
        btnp1highkick.interactable = false;
        btnp1ulti.interactable = false;
        videoplayer.clip = p1highpunchmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = true;
        turnChecker();
        Debug.Log("player1: highpunch missed");
        }

//--[P1HP-HIT]
        else if (globalaccuracy <= 55)
        {
            if (p1cinemode == false) //normal
            {
            setdelaytime = 1.1f;
            delayedsfxpunch();
            setdelaytime = 1.4f;
            delayedsfxpunch();
            btnp1lowpunch.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1highpunchhit;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = true;
            turnChecker();
            Debug.Log("player1: highpunch succeed");
            }

//--[P1HPCINE-HIT]
            else if (p1cinemode == true) //cine highpunchs
            {
            setdelaytime = 0.5f;
            delayedsfxpunch();
            setdelaytime = 0.8f;
            delayedsfxpunch();
            btnp1lowpunch.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1highpunchhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: highpunch hit CINE");
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
            }
        }
    }
//------------------------



//---------------[P1-LOWKICK]
//--[P1LK-MISS]

    public void p1lowkickhitvoid()
    {
        
        dealDamage(p2hp, 6, 65);// damage & accuracy
        if (globalaccuracy > 65)
        {
        btnp1lowpunch.interactable = false;
        btnp1highpunch.interactable = false;
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
            setdelaytime = 0.8f;
            delayedsfx();
            btnp1lowpunch.interactable = false;
            btnp1highpunch.interactable = false;
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1lowkickhit;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = true;
            turnChecker();
            Debug.Log("player1: lowkick hit");
            }

//--[P1LKCINE-HIT]
            else if (p1cinemode == true) //cine lowkick
            {
            videoplayer.isLooping = false;
            killingcinesfx.Play();
            setdelaytime = 1.5f;
            delayedsfx();
            btnp1lowpunch.interactable = false;
            btnp1highpunch.interactable = false;
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1lowkickhitcine;
            Debug.Log("player1: lowkick hit CINE");
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
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
        btnp1lowpunch.interactable = false;
        btnp1highpunch.interactable = false;
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
            setdelaytime = 1.2f;
            delayedsfx();
            btnp1lowpunch.interactable = false;
            btnp1highpunch.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1highkickhit;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = true;
            turnChecker();
            Debug.Log("player1: highkick succeed");
            }

//--[P1LKCINE-HIT]
            else if (p1cinemode == true) //cine highkick
            {
            videoplayer.isLooping = false;
            setdelaytime = 1.1f;
            delayedsfx();
            btnp1lowpunch.interactable = false;
            btnp1highpunch.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p1highkickhitcine;
            Debug.Log("player1: highkick hit CINE");
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
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
        setdelaytime = 5f;
        activatespeechmuter();
        p1ultispeech.Play();
        btnp1lowpunch.interactable = false;
        btnp1highpunch.interactable = false; 
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
            setdelaytime = 5f;
            activatespeechmuter();
            p1ultispeech.Play();
            btnp1lowpunch.interactable = false;
            btnp1highpunch.interactable = false;
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

//--[P1HULTICINE-HIT]
            else if (p1cinemode == true)
            {
            setdelaytime = 5f;
            activatespeechmuter();
            p1ultispeech.Play();
            btnp1lowpunch.interactable = false;
            btnp1highpunch.interactable = false;
            btnp1lowkick.interactable = false;
            btnp1highkick.interactable = false;
            videoplayer.clip = p1ultihitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: ulti succeed");
            p1nomoreulti = true;
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
            }
        }
    }
//------------------------
//-----------------------------------------------------------------------


//-----------------------------[PLAYER 2 ATTACK]----------------------------------// 



//---------------[P2-LOWPUNCH]
//--[P2LP-MISS]
    public void p2lowpunchhitvoid()
    {
        dealDamage(p1hp, 3, 75);// damage & accuracy
        if (globalaccuracy > 75)
        {
        btnp2highpunch.interactable = false;
        btnp2lowkick.interactable = false;
        btnp2highkick.interactable = false;
        btnp2ulti.interactable = false;
        videoplayer.clip = p2lowpunchmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: lowpunch missed");
        }

//--[P2LP-HIT]

        else if (globalaccuracy <= 75)
        {
            if (p2cinemode == false)
            {
            setdelaytime = 0.6f;
            delayedsfxpunch();
            setdelaytime = 0.9f;
            delayedsfxpunch();
            btnp2highpunch.interactable = false;
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            btnp2ulti.interactable = false;
            videoplayer.clip = p2lowpunchhit;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = false;
            turnChecker();
            Debug.Log("player2: lowpunch hit");
            }

//--[P2LPCINE-HIT]
            else if (p2cinemode == true)
            {
            setdelaytime = 1.3f;
            delayedsfxpunch();
            setdelaytime = 1.6f;
            delayedsfxpunch();
            btnp2highpunch.interactable = false;
            btnp2lowkick.interactable = false;
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p2lowpunchhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowpunch hit CINE");
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
            }
        }
    }
//------------------------


//---------------[P2-HIGHPUNCH]
//--[P2HP-MISS]
    public void p2highpunchhitvoid()
    {
        dealDamage(p1hp, 8, 55);// damage & accuracy
        if (globalaccuracy > 55)
        {
        btnp2lowpunch.interactable = false;
        btnp2lowkick.interactable = false;
        btnp2highkick.interactable = false;
        btnp2ulti.interactable = false;
        videoplayer.clip = p2highpunchmiss;
        videoplayer.isLooping = false;
        videoplayer.loopPointReached += checkOver;
        turn = false;
        turnChecker();
        Debug.Log("player2: highpunch missed");
        }

//--[P2HP-HIT]

        else if (globalaccuracy <= 55)
        {

            if (p2cinemode == false)
            {
            setdelaytime = 0.9f;
            delayedsfxpunch();
            setdelaytime = 1.2f;
            delayedsfxpunch();
            btnp2lowpunch.interactable = false;
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            btnp2ulti.interactable = false;
            videoplayer.clip = p2highpunchhit;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = false;
            turnChecker();
            Debug.Log("player2: highpunch hit");
            }

//--[P2HPCINE-HIT]
            else if (p2cinemode == true)
            {
            setdelaytime = 0.9f;
            delayedsfxpunch();
            setdelaytime = 1.2f;
            delayedsfxpunch();
            btnp2lowpunch.interactable = false;
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            btnp2ulti.interactable = false;
            videoplayer.clip = p2highpunchhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowpunch hit CINE");
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
            }
        }
    }
//------------------------


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
            setdelaytime = 1f;
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

//--[P2LKCINE-HIT]
            else if (p2cinemode == true)
            {
            setdelaytime = 1.7f;
            delayedsfx();
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p2lowkickhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowkick hit CINE");
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
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
            setdelaytime = 1.5f;
            delayedsfx();
            btnp2lowkick.interactable = false;
            btnp2ulti.interactable = false;
            videoplayer.clip = p2highkickhit;
            videoplayer.isLooping = false;
            videoplayer.loopPointReached += checkOver;
            turn = false;
            turnChecker();
            Debug.Log("player2: highkick hit");
            }

//--[P2HKCINE-HIT]
            else if (p2cinemode == true)
            {
            setdelaytime = 1.5f;
            delayedsfx();
            btnp1highkick.interactable = false;
            btnp1ulti.interactable = false;
            videoplayer.clip = p2highkickhitcine;
            videoplayer.isLooping = false;
            Debug.Log("player1: lowkick hit CINE");
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
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
        setdelaytime = 4f;
        activatespeechmuter();
        p2ultispeech.Play();
        p2speech1.Pause();
        p2speech2.Pause();
        p2speech3.Pause();
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
            setdelaytime = 4f;
            activatespeechmuter();
            p2ultispeech.Play();
            p2speech1.Pause();
            p2speech2.Pause();
            p2speech3.Pause();
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

//--[P2ULTICINE-HIT]
            else if (p2cinemode == true)
            {
            setdelaytime = 4f;
            activatespeechmuter();
            p2ultispeech.Play();
            p2speech1.Pause();
            p2speech2.Pause();
            p2speech3.Pause();
            btnp2lowkick.interactable = false;
            btnp2highkick.interactable = false;
            videoplayer.clip = p2ulticine;
            videoplayer.isLooping = false;
            Debug.Log("player2: ulti succeed");
            p2nomoreulti = true;   
            lowhealthbgm.Pause();
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            nomorebuttons();
            delayedendgame();
            }
        }
    }
//------------------------



    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void delayedsfxpunch()
    {
    StartCoroutine(delayedsfxpunchIE());
    delayedsfxIE();
    }

    IEnumerator delayedsfxpunchIE()
    {
        yield return new WaitForSeconds(setdelaytime);
        int speechran = Random.Range(0, 3);
            if (speechran == 1)
            {
                punchsfx1.Play(); 
            }
            else if (speechran == 2)
            {
                punchsfx2.Play(); 
            }
            else if (speechran == 3)
            {
                punchsfx3.Play(); 
            }
    }


    public void delayedsfx()
    {
    StartCoroutine(delayedsfxIE());
    delayedsfxIE();
    }

    IEnumerator delayedsfxIE()
    {
        yield return new WaitForSeconds(setdelaytime);
        int speechran = Random.Range(0, 3);
            if (speechran == 1)
            {
                kicksfx1.Play(); 
            }
            else if (speechran == 2)
            {
                kicksfx2.Play(); 
            }
            else if (speechran == 3)
            {
                kicksfx3.Play(); 
            }
    }

    public void delayedendgame()
    {
    StartCoroutine(delayedendgameIE());
    delayedendgameIE();
    }

    public string playerwinner;
    IEnumerator delayedendgameIE()
    {
        yield return new WaitForSeconds(5f);
        if (playerwinner == "player1")
        {
            p1wins.playerwinnerstr = p1namestr;
            Debug.Log("p1wins");
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene(7);
        }
        else if (playerwinner == "player2")
        {
            p1wins.playerwinnerstr = p2namestr;
            Debug.Log("p2wins");
            battlebgm.instance.GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene(8);
        }   
    }


    public void endgamefader()
    {
        StartCoroutine(endgamefaderIE());
        endgamefaderIE();
    }

    IEnumerator endgamefaderIE()
    {
        yield return new WaitForSeconds(4f);
        fadeIn = true;
    }


    public void activatespeechmuter()
    {
    StartCoroutine(activatespeechmuterIE());
    }

    IEnumerator activatespeechmuterIE()
    {
        enable_pauseallspeech = true;
        yield return new WaitForSeconds(setdelaytime);
        enable_pauseallspeech = false;
    }



    public void nomorebuttons()
    {
    btnp1highkick.interactable = false;
    btnp2highkick.interactable = false;
    btnp1highpunch.interactable = false;
    btnp2highpunch.interactable = false;
    btnp1lowkick.interactable = false;
    btnp2lowkick.interactable = false;
    btnp1lowpunch.interactable = false;
    btnp1lowpunch.interactable = false;
    btnp1ulti.interactable = false;
    btnp2ulti.interactable = false;

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