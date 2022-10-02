using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class p2healthbar : MonoBehaviour
{
    public Image fillImage;
    private Slider p2healthslider;
    float currentVelocity = 0;
    public int x = video.p2hp;
    public int y;
    public int z; 
    public int ztemp;

    // Start is called before the first frame update
    void Awake()
    {
        p2healthslider = GetComponent<Slider>();
        z = video.p2hp;
        p2healthslider.value = video.p2hp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    y = video.p2hp;
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
        float p1healthhold = Mathf.SmoothDamp(p2healthslider.value, video.p2hp, ref currentVelocity, 100 * Time.deltaTime);
        p2healthslider.value = p1healthhold;
        ztemp = z-y;
        z = z-ztemp;
    }

}
