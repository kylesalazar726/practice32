using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Handler : MonoBehaviour
{
    public float gameDuration;
    public GameObject timerGO;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayedHellowWorld());
    }

    // Update is called once per frame
    void Update()
    {
        timerGO.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = gameDuration + "";
    }

    void FixedUpdate()
    {
        gameDuration -= Time.deltaTime;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator delayedHellowWorld()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("delayed message");
    }
}
