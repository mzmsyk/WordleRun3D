using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/* Copyright® Polyque Games -Mücahit Aygün : All rights reserved*/

public class Intro : MonoBehaviour
{
    VideoPlayer player;
    bool introStarted = false;

    [Header("Referances")]
    [SerializeField] private List<GameObject> toSetActive = new List<GameObject>();
    [SerializeField] private GameObject camIntro, blackCanvas;

    void Awake()
    {
        player = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        if(Singleton.instance.isFirstTime)
        StartCoroutine(introo());

        else
        {
            foreach (GameObject obje in toSetActive)
            {
                obje.SetActive(true);
            }

            blackCanvas.SetActive(false);
            Destroy(camIntro);
            Destroy(gameObject);
        }
    }

    IEnumerator introo()
    {
        while (true)
        {
            // Intro videosu gösterilmeye hazýr ama henüz gösterilmeye baþlanmadýðý an
            if (player.isPrepared && !introStarted)
            {

                introStarted = true;
                StartCoroutine(blackscreen());
            }
            // Intronun durduðu an
            if (player.isPaused && introStarted)
            {
                Singleton.instance.isFirstTime = false;
                foreach (GameObject obje in toSetActive)
                {
                    obje.SetActive(true);
                    //int kayitliLevel= PlayerPrefs.GetInt("kayit");
                    //if (kayitliLevel == 0)
                    //{
                    //    SceneManager.LoadScene(kayitliLevel + 1);
                    //}
                    //else
                    //{
                    //    SceneManager.LoadScene(kayitliLevel);
                    //}
                    
                }
                
                Destroy(camIntro);
                Destroy(gameObject);
                
                break;
                
            }
            
            yield return null;
        }
    }
    // Intro gösterimi baþladýktan sonra siyah ekranýn silinmesi
    IEnumerator blackscreen()
    {
        yield return new WaitForSeconds(.1f);
        
        blackCanvas.SetActive(false);
        yield return new WaitForSeconds(2.2f);
        int kayitliLevel = PlayerPrefs.GetInt("kayit");
        if (kayitliLevel == 0)
        {
            SceneManager.LoadScene(kayitliLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(kayitliLevel);
        }
    }

}
