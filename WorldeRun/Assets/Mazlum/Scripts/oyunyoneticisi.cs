using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class oyunyoneticisi : MonoBehaviour
{
    
    GameObject Karakter;
    GameObject Map;
    public string sonrakiSahneIsmi;
    public GameObject SonrakiLevelPanel;
    public GameObject kaybetmePanel;
    public GameObject kelimePanel;
    public GameObject kelimePanel2;
    public GameObject solDoluYildiz;
    public GameObject ortaDoluYildiz;
    public GameObject sagDoluYildiz;
    public TextMeshProUGUI skorText;
    public TextMeshProUGUI skorText2;
    public TextMeshProUGUI canText;
    public TextMeshProUGUI canText2;
    public TextMeshProUGUI dolarText;
    public TextMeshProUGUI dolarTextBoxLetter;
    public TextMeshProUGUI dolarTextBoxChange;
    public GameObject letterBox;
    public GameObject changeBox;
    public GameObject letterBoxReklam;
    public GameObject changeBoxReklam;
    public GameObject BaslaButon;
    public GameObject dolarImage;

    public int rastgeleDeger;
    public int rastgeleDeger2;
    GameObject HarfSpawnlama;
    public bool kontrol = false;
    public bool kontrol2 = true;
    public bool kontrol3 = true;
    public bool kontrolKelime = true;
    public bool kontrolLetter = false;
    public bool kontrolChange = false;
    string adUnitId;
    private RewardedAd odulluReklam;
    private InterstitialAd gecisliReklam;
    public static int dolarKayit;
    public TextMeshProUGUI letterLevelText;
    public static int letterLevel=1;
    public static int letterSayac=100;
    public TextMeshProUGUI changeLevelText;
    public static int changeLevel = 1;
    public static int changeSayac = 100;
    public GameObject efectDigerLevel;
    public Transform efectYeri;
    public GameObject oyunAdi;
    private bool canCheck = true;
    void Start()
    {
        

        letterLevelText.text ="Lv." +letterLevel.ToString();
        changeLevelText.text = "Lv." + changeLevel.ToString();
        dolarKayit = PlayerPrefs.GetInt("dolarkayit")/*+dolarKayit*/;
        dolarTextBoxLetter.text = letterSayac.ToString();
        dolarTextBoxChange.text = changeSayac.ToString();
        
        kontrol2 = true;
        kontrol3 = true;
        kontrolChange = false;
        kontrolLetter = false;
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        Karakter = GameObject.FindGameObjectWithTag("Player");
        Map = GameObject.FindGameObjectWithTag("map");
        HarfSpawnlama = GameObject.FindGameObjectWithTag("map");
        canText.text = Karakter.GetComponent<karakterhareket>().cann.ToString();
        if (dolarKayit <= letterSayac)
        {
            letterBoxReklam.SetActive(true);
            letterBox.SetActive(false);

        }
        else
        {
            letterBoxReklam.SetActive(false);
            letterBox.SetActive(true);
        }
        if (dolarKayit <= changeSayac)
        {
            changeBoxReklam.SetActive(true);
            changeBox.SetActive(false);

        }
        else
        {
            changeBoxReklam.SetActive(false);
            changeBox.SetActive(true);
        }



    }

    
    void Update()
    {
        
        
        if (kontrolLetter==true)
        {
            kelimePanel.GetComponent<RectTransform>().DOScale(0.81442F, 2).SetEase(Ease.OutBack);
            kontrolChange = false;
            
            
        }
        if (kontrolChange == true)
        {
            kelimePanel2.GetComponent<RectTransform>().DOScale(0.81442F, 2).SetEase(Ease.OutBack);
            kontrolLetter = false;
            
            
        }
        skorText.text = "Your Score: "+Karakter.GetComponent<karakterhareket>().skor.ToString();
        skorText2.text = "Your Score: " + Karakter.GetComponent<karakterhareket>().skor.ToString();
        canText.text = Karakter.GetComponent<karakterhareket>().cann.ToString();
        canText2.text = Karakter.GetComponent<karakterhareket>().cann.ToString();
        dolarText.text = karakterhareket.dolarSayac.ToString();
        //dolarText.text = dolarKayit.ToString();
        if (Karakter.GetComponent<karakterhareket>().toplamCan <= Karakter.GetComponent<karakterhareket>().canSayac && canCheck)
        {
            Debug.Log("Karakter öldü");
            canCheck = false;
            Karakter.GetComponent<karakterhareket>().karakterAnim.SetBool("defeat", true);
            Map.GetComponent<mapdondurme>().kontrol = false;
            Karakter.GetComponent<karakterhareket>().sag1 = false;
            Karakter.GetComponent<karakterhareket>().sol1 = false;
            
            StartCoroutine(OyunBittiPanel());
        }
        if (Karakter.GetComponent<karakterhareket>().harfSayac >= Karakter.GetComponent<karakterhareket>().harfler.Length && canCheck)
        {
            canCheck = false;
            Karakter.GetComponent<karakterhareket>().karakterAnim.SetBool("victory", true);
            Map.GetComponent<mapdondurme>().kontrol = false;
            Karakter.GetComponent<karakterhareket>().sag1 = false;
            Karakter.GetComponent<karakterhareket>().sol1 = false;
            Instantiate(efectDigerLevel, efectYeri.position, Quaternion.identity);
            
            StartCoroutine(DigerLevelPanel());
            
        }
        if (Karakter.GetComponent<karakterhareket>().harfSayac2 >= Karakter.GetComponent<karakterhareket>().harflerKlon.Length && canCheck)
        {
            canCheck = false;
            Karakter.GetComponent<karakterhareket>().karakterAnim.SetBool("victory", true);
            Map.GetComponent<mapdondurme>().kontrol = false;
            Karakter.GetComponent<karakterhareket>().sag1 = false;
            Karakter.GetComponent<karakterhareket>().sol1 = false;
            Instantiate(efectDigerLevel, efectYeri.position, Quaternion.identity);
            
            StartCoroutine(DigerLevelPanel());

        }
        if (Karakter.GetComponent<karakterhareket>().canSayac==0)
        {
            solDoluYildiz.SetActive(true);
            ortaDoluYildiz.SetActive(true);
            sagDoluYildiz.SetActive(true);
        }
        if (Karakter.GetComponent<karakterhareket>().canSayac == 1)
        {
            solDoluYildiz.SetActive(true);
            ortaDoluYildiz.SetActive(true);
            sagDoluYildiz.SetActive(false);
        }
        if (Karakter.GetComponent<karakterhareket>().canSayac == 2)
        {
            solDoluYildiz.SetActive(true);
            ortaDoluYildiz.SetActive(false);
            sagDoluYildiz.SetActive(false);
        }
    }
    IEnumerator OyunBittiPanel()
    {
        yield return new WaitForSeconds(2f);

        HarfSpawnlama.GetComponent<mapdondurme>().kontrol = false;
        Karakter.GetComponent<karakterhareket>().sag1 = false;
        Karakter.GetComponent<karakterhareket>().sol1 = false;
        kaybetmePanel.SetActive(true);
        dolarImage.SetActive(false);
        kaybetmePanel.GetComponent<RectTransform>().DOScale(1, 2).SetEase(Ease.OutBack);
        kelimePanel.SetActive(false);
        kelimePanel2.SetActive(false);
        Ads.instance.ShowInter2();
    }
    IEnumerator DigerLevelPanel()
    {
        
        yield return new WaitForSeconds(2f);
       
        

        HarfSpawnlama.GetComponent<mapdondurme>().kontrol = false;
        Karakter.GetComponent<karakterhareket>().sag1 = false;
        Karakter.GetComponent<karakterhareket>().sol1 = false;
        SonrakiLevelPanel.SetActive(true);
        dolarImage.SetActive(false);
        SonrakiLevelPanel.GetComponent<RectTransform>().DOScale(1, 2).SetEase(Ease.OutBack);
        kelimePanel.SetActive(false);
        kelimePanel2.SetActive(false);
        Ads.instance.ShowInter();
        
    }
    public void DigerLevel()
    {
        
        SceneManager.LoadScene(sonrakiSahneIsmi);
    }
    public void OyunBitti()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AnaMenuDon()
    {
        SceneManager.LoadScene(0);
    }
    public void LetterBox()
    {
        Debug.Log("letterBox");
         Ads.instance.ShowRewardedLetter();
        

    }

    public void OyuncuyaOdulVer()
    {
        
        letterLevel++;
        //letterSayac += 100;
        Debug.Log("ödül verildi.");
        kelimePanel2.SetActive(false);
        
        rastgeleDeger = UnityEngine.Random.Range(0, Karakter.GetComponent<karakterhareket>().harfler.Length);
        Debug.Log(rastgeleDeger);
        Karakter.GetComponent<karakterhareket>().imageHarfler[rastgeleDeger].SetActive(true);
        
        kontrolLetter = true;
        kontrolChange = false;
        kontrolKelime = true;
        Karakter.GetComponent<karakterhareket>().kontrol4 = true;
        Karakter.GetComponent<karakterhareket>().kontrol5 = false;
        kontrol = true;
        letterBox.SetActive(false);
        changeBox.SetActive(false);
        letterBoxReklam.SetActive(false);
        changeBoxReklam.SetActive(false);
        BaslaButon.SetActive(false);
        letterLevelText.gameObject.SetActive(false);
        changeLevelText.gameObject.SetActive(false);
        oyunAdi.SetActive(false);


    }
    public void LetterBoxDolar()
    {
        if (dolarKayit>=letterSayac)
        {
            dolarKayit -= letterSayac;
            karakterhareket.dolarSayac -= letterSayac;
            letterLevel++;
            letterSayac += 100;
            Debug.Log("ödül verildi.");
            kelimePanel2.SetActive(false);
            Karakter.GetComponent<karakterhareket>().kontrol4 = true;
            Karakter.GetComponent<karakterhareket>().kontrol5 = false;
            rastgeleDeger = UnityEngine.Random.Range(0, Karakter.GetComponent<karakterhareket>().harfler.Length);
            Debug.Log(rastgeleDeger);
            Karakter.GetComponent<karakterhareket>().imageHarfler[rastgeleDeger].SetActive(true);

            kontrolLetter = true;
            kontrolChange = false;
            kontrolKelime = true;
            kontrol = true;
            letterBox.SetActive(false);
            changeBox.SetActive(false);
          
            letterBoxReklam.SetActive(false);
            changeBoxReklam.SetActive(false);
            BaslaButon.SetActive(false);
            letterLevelText.gameObject.SetActive(false);
            changeLevelText.gameObject.SetActive(false);
            oyunAdi.SetActive(false);
        }
        
    }
    public void ChangeBox()
    {

        Ads.instance.ShowRewardedChange();
        
    }
    public void OyuncuyaOdulVer2()
    {
        changeLevel++;
        kontrolChange = true;
        kontrolLetter = false;
        kontrolKelime = false;
        Karakter.GetComponent<karakterhareket>().kontrol4 = false;
        Karakter.GetComponent<karakterhareket>().kontrol5 = true;
        kontrol = false;
        kelimePanel.SetActive(false);
        changeBox.SetActive(false);
        letterBoxReklam.SetActive(false);
        changeBoxReklam.SetActive(false);
        BaslaButon.SetActive(false);
        oyunAdi.SetActive(false);
        letterLevelText.gameObject.SetActive(false);
        changeLevelText.gameObject.SetActive(false);
        
    }
    public void ChangeBoxDolar()
    {
        if (dolarKayit>=changeSayac)
        {
            dolarKayit -= changeSayac;
            karakterhareket.dolarSayac -= changeSayac;
            changeLevel++;
            changeSayac += 100;
            kontrolChange = true;
            kontrolLetter = false;
            kontrolKelime = false;
            Karakter.GetComponent<karakterhareket>().kontrol4 = false;
            Karakter.GetComponent<karakterhareket>().kontrol5 = true;
            kontrol = false;
            kelimePanel.SetActive(false);
            changeBox.SetActive(false);
            letterBoxReklam.SetActive(false);
            changeBoxReklam.SetActive(false);
            BaslaButon.SetActive(false);
            oyunAdi.SetActive(false);
            letterLevelText.gameObject.SetActive(false);
            changeLevelText.gameObject.SetActive(false);
        }
        
    }
    public void OyunaBasla()
    {
        Karakter.GetComponent<karakterhareket>().kontrol4 = true;
        BaslaButon.SetActive(false);
        kontrolLetter = true;
        kontrolChange = false;
        kontrolKelime = true;
        letterBox.SetActive(false);
        changeBox.SetActive(false);
        letterBoxReklam.SetActive(false);
        changeBoxReklam.SetActive(false);
        kelimePanel.SetActive(true);
        kelimePanel2.SetActive(false);
        letterLevelText.gameObject.SetActive(false);
        changeLevelText.gameObject.SetActive(false);
        oyunAdi.SetActive(false);
        kontrol = false;
        kontrolLetter = true;
        kontrolChange = false;
    }
    
}
