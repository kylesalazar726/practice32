using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class p1healthbar : MonoBehaviour
{
    public Image fillImage;
    private Slider p1healthslider;
    float currentVelocity = 0;
    public int x = video.p1hp;
    public int y;
    public int z; 
    public int ztemp;

    // Start is called before the first frame update
    void Awake()
    {
        p1healthslider = GetComponent<Slider>();
        z = video.p1hp;
        p1healthslider.value = video.p1hp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    y = video.p1hp;
        if (y != z)
        {   
            p1healthbardamagedelay();
        }
    }

    public void p1healthbardamagedelay()
    {
    StartCoroutine(p1healthbardamagedelayIE());
    }

    IEnumerator p1healthbardamagedelayIE()
    {
        yield return new WaitForSeconds(1.2f);
        float p1healthhold = Mathf.SmoothDamp(p1healthslider.value, video.p1hp, ref currentVelocity, 100 * Time.deltaTime);
        p1healthslider.value = p1healthhold;
        ztemp = z-y;
        z = z-ztemp;
    }

}
