using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anamenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ayarlarPanel;
    public GameObject titresimAc;
    public GameObject TitresimKapat;
    public GameObject sesAc;
    public GameObject sesKapat;
    public GameObject geriTusu;
    public GameObject sesAcik;
    public GameObject sesKapali;
    public GameObject ayarlarButton;
    //public GameObject oyunAdi;
    void Start()
    {
        //Ads.instance.raklamKontrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sesDurum")==1)
        {
            sesAc.SetActive(false);
            sesKapali.SetActive(true);
        }
        if (PlayerPrefs.GetInt("sesDurum")==0)
        {
            sesAc.SetActive(true);
            sesKapali.SetActive(false);
        }
        if (PlayerPrefs.GetInt("titresimDurum")==1)
        {
            titresimAc.SetActive(false);
            TitresimKapat.SetActive(true);
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 0)
        {
            titresimAc.SetActive(true);
            TitresimKapat.SetActive(false);
        }
    }
    public void BaslaButton()
    {
        int kayitliLevel = PlayerPrefs.GetInt("kayit");
        //oyunAdi.SetActive(false);
        ayarlarButton.SetActive(false);
        gameObject.SetActive(false);
        SceneManager.LoadScene(kayitliLevel);
        if (kayitliLevel == 0)
        {
            SceneManager.LoadScene(kayitliLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(kayitliLevel);
        }

    }
    public void GeriTusu()
    {
        ayarlarPanel.SetActive(false);
        ayarlarButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void AyarlarButton()
    {
        ayarlarPanel.SetActive(true);
        ayarlarButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void SesDurum(string ses)
    {
        if (ses=="acik")
        {
            sesAc.SetActive(false);
            sesKapali.SetActive(true);
            PlayerPrefs.SetInt("sesDurum", 1);
        }
        if (ses=="kapali")
        {
            sesAc.SetActive(true);
            sesKapali.SetActive(false);
            PlayerPrefs.SetInt("sesDurum", 0);
        }
        
    }
    public void Titresim(string titresim)
    {
        if (titresim=="acik")
        {
            titresimAc.SetActive(false);
            TitresimKapat.SetActive(true);
            PlayerPrefs.SetInt("titresimDurum", 1);
        }
        if (titresim=="kapali")
        {
            titresimAc.SetActive(true);
            TitresimKapat.SetActive(false);
            PlayerPrefs.SetInt("titresimDurum", 0);
        }
    }
    

}
