using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.NiceVibrations;

public class karakterhareket : MonoBehaviour
{
    public float yanHiz;
    Rigidbody fizik;
    bool sag, sol,orta;
    public bool sag1=true, sol1=true;
    public float ziplama;
    public bool ziplamaHakki=true;
    int ziplamaSayac;
    GameObject Map;
    public Animator karakterAnim;
    
    GameObject HarfSpawnlama;
    int sayac = 0;
    public GameObject[] harfler;
    public GameObject[] harflerKlon;
    public bool kontrol = false;
    public GameObject efectDogruCarpma;
    public GameObject efectDolar;
    public GameObject efectYanlisCarpma;
    public GameObject efectSonDogruHarf;
    public int canSayac=0;
    public int toplamCan=3;
    public int harfSayac=0;
    public int harfSayac2 = 0;
    bool kontrol2=false;
    bool kontrol3 = false;
    public bool kontrol4 = false;
    public bool kontrol5 = false;
    Vector3 sonPos;
    public int skor;
    public GameObject[] imageHarfler;
    public GameObject[] imageHarflerKlon;
    public int cann;
    GameObject OyunYoneticisi;
    public static int dolarSayac;
    public AudioSource sesDogru;
    public AudioSource sesYanlis;
    public AudioSource sesKazanma;
    public Transform efectOlusmaYeri;
    public HapticTypes hapticTypes3 = HapticTypes.LightImpact;
    public HapticTypes hapticTypes2 = HapticTypes.SoftImpact;
    public HapticTypes hapticTypes1 = HapticTypes.RigidImpact;
    public static bool kontrolTitresim = true;
    

    void Start()
    {
        
        //dolarSayac = 0;
        skor = 0;
        cann = 3;
        harfSayac = 0;
        harfSayac2 = 0;
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = Vector3.zero;
        OyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisi");
        Map = GameObject.FindGameObjectWithTag("map");
        karakterAnim = GetComponent<Animator>();
        HarfSpawnlama = GameObject.FindGameObjectWithTag("map");
        if (Map.GetComponent<mapdondurme>().kontrol == false)
        {
            karakterAnim.SetBool("karakterRun", false);
            
            HarfSpawnlama.GetComponent<harfspawnlama>().kontrol = false;
        }
        sonPos = transform.position;
    }

    
    void Update()
    {
        if (PlayerPrefs.GetInt("sesDurum")==1)
        {
            sesDogru.mute = true;
            sesKazanma.mute = true;
            sesYanlis.mute = true;
        }
        if (PlayerPrefs.GetInt("sesDurum") == 0)
        {
            sesDogru.mute = false;
            sesKazanma.mute = false;
            sesYanlis.mute = false;
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 1)
        {
            kontrolTitresim = false;
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 0)
        {
            kontrolTitresim = true;
        }
        PlayerPrefs.SetInt("dolarkayit", dolarSayac);
        if (kontrol2 == true)
        {
            kontrol3 = false;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.21f, 8.15f, 16.99f), 0.09f);
        }
        if (kontrol3==true)
        {
            kontrol2 = false;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.5f, 10.49f, 15.9f), 0.09f);
        }
        
            
        
        transform.rotation = Quaternion.Euler(-19.576f, 170.283f, 3.284f);
        
       
        if (Map.GetComponent<mapdondurme>().kontrol==true)
        {
            karakterAnim.SetBool("karakterRun", true);
        }
        
        if (kontrol4 == true)
        {
            kontrol4 = false;
            Map.GetComponent<mapdondurme>().kontrol = true;
            karakterAnim.SetBool("karakterRun", true);
            
            HarfSpawnlama.GetComponent<harfspawnlama>().kontrol = true;
            HarfSpawnlama.GetComponent<harfspawnlama>().kontrol2 = false;
            OyunYoneticisi.GetComponent<oyunyoneticisi>().letterBox.SetActive(false);
            OyunYoneticisi.GetComponent<oyunyoneticisi>().changeBox.SetActive(false);
        }
        if (kontrol5 == true)
        {
            kontrol5 = false;
            Map.GetComponent<mapdondurme>().kontrol = true;
            karakterAnim.SetBool("karakterRun", true);
            
            HarfSpawnlama.GetComponent<harfspawnlama>().kontrol2 = true;
            HarfSpawnlama.GetComponent<harfspawnlama>().kontrol = false;
            OyunYoneticisi.GetComponent<oyunyoneticisi>().letterBox.SetActive(false);
            OyunYoneticisi.GetComponent<oyunyoneticisi>().changeBox.SetActive(false);
        }
        if (Input.touchCount>0)
        {
            Touch parmak = Input.GetTouch(0);
           
            if (parmak.deltaPosition.x>5)
            {
                sag = true;
                sol = false;
                orta = false;
            }
            if (parmak.deltaPosition.x<-5)
            {
                sol = true;
                sag = false;
                orta = false;
            }
            if (parmak.deltaPosition.x==0)
            {
                orta = true;
                sol = false;
                sag = false;
            }
           
            
            if (sag==true&&sag1==true)
            {
                Vector3 sagHareket = new Vector3(-3.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, sagHareket, yanHiz*Time.deltaTime);
                transform.rotation = Quaternion.Euler(-19.624f, 188.774f, -2.967f);
                
            }
            if (sol == true&&sol1==true)
            {
                Vector3 solHareket = new Vector3(4.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, solHareket, yanHiz * Time.deltaTime);
                transform.rotation = Quaternion.Euler(-17.796f, 152.833f, 8.914f);
            }
            if (orta == true)
            {
                Vector3 ortaHareket = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.position = ortaHareket;
                transform.rotation = Quaternion.Euler(-19.576f, 170.283f, 3.284f);
            }
        }
        
        
    }
    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "dogru")
        {

            
            
            sayac++;
            
            if (OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrol == true)
            {
                harfSayac=1;
                OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrol = false;
            }
            
            
            for (int i = 0; i < harfler.Length; i++)
            {
                if (col.gameObject.name == harfler[i].name && OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrolKelime == true)
                {
                    if (col.gameObject.name==imageHarfler[i].name)
                    {
                        imageHarfler[i].SetActive(true);
                    }
                    
                    if (kontrolTitresim==true)
                    {
                        MMVibrationManager.Haptic(hapticTypes1, false, true, this);
                    }
                    
                    col.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    
                    sesDogru.Play();
                    
                    skor += 10;
                    
                    
                    
                    HarfSpawnlama.transform.GetChild(i + 3).gameObject.SetActive(false);
                    col.gameObject.transform.parent = null;
                    karakterAnim.SetBool("yumruk", true);
                    karakterAnim.SetBool("karakterRun", true);
                    karakterAnim.SetBool("jump", false);
                    if (harfSayac != harfler.Length-1)
                    {
                        Instantiate(efectDogruCarpma, efectOlusmaYeri.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        
                        sesKazanma.Play();
                        Instantiate(efectSonDogruHarf, efectOlusmaYeri.transform.position, Quaternion.identity);

                    }
                    yield return new WaitForSeconds(0.1f);
                   
                    Invoke("animtekrar", 0.1f);
                    col.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    harfler[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    
                    harfSayac++;
                    Debug.Log("normal: " + harfSayac);
                    yield return new WaitForSeconds(2f);
                    col.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            for (int i = 0; i < harflerKlon.Length; i++)
            {
                if (col.gameObject.name == harflerKlon[i].name&&OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrolKelime==false)
                {
                    if (col.gameObject.name == imageHarflerKlon[i].name)
                    {
                        imageHarflerKlon[i].SetActive(true);
                    }
                    if (kontrolTitresim == true)
                    {
                        MMVibrationManager.Haptic(hapticTypes1, false, true, this);
                    }
                    
                    col.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    
                    sesDogru.Play();
                    
                    skor += 10;
                    
                    
                    
                    HarfSpawnlama.transform.GetChild(i + 3).gameObject.SetActive(false);
                    col.gameObject.transform.parent = null;
                    karakterAnim.SetBool("yumruk", true);
                    karakterAnim.SetBool("karakterRun", true);
                    karakterAnim.SetBool("jump", false);
                    if (harfSayac2 != harflerKlon.Length-1)
                    {
                        Instantiate(efectDogruCarpma, efectOlusmaYeri.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        
                        sesKazanma.Play();
                        Instantiate(efectSonDogruHarf, efectOlusmaYeri.transform.position, Quaternion.identity);

                    }
                    yield return new WaitForSeconds(0.1f);

                    HarfSpawnlama.transform.GetChild(i + 3).gameObject.SetActive(false);

                    
                    Invoke("animtekrar", 0.1f);
                    col.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    
                    harflerKlon[i].GetComponent<MeshRenderer>().material.color = Color.red;
                    
                    harfSayac2++;
                    Debug.Log("klon: " + harfSayac2);
                    yield return new WaitForSeconds(2f);
                    col.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    

                }
            }


            Invoke("animtekrar", 0.1f);
            

        }
        if (col.gameObject.tag=="yanlis")
        {
            if (kontrolTitresim == true)
            {
                MMVibrationManager.Haptic(hapticTypes2, false, true, this);
            }
            
            sesYanlis.Play();
            Instantiate(efectYanlisCarpma, efectOlusmaYeri.transform.position, Quaternion.identity);
            karakterAnim.SetBool("geritepme", true);
            canSayac++;
            cann =toplamCan-canSayac;
            
            StartCoroutine(Kapat());
            //col.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            yield return new WaitForSeconds(0.7f);
            karakterAnim.SetBool("geritepme", false);
            
            yield return new WaitForSeconds(2.5f);
            
            
            
        }
        if (col.gameObject.tag=="dolar")
        {
            if (kontrolTitresim == true)
            {
                MMVibrationManager.Haptic(hapticTypes3, false, true, this);
            }
            sesDogru.Play();
            col.gameObject.SetActive(false);
            Instantiate(efectDolar, efectOlusmaYeri.transform.position, Quaternion.identity);
            //col.gameObject.transform.parent = null;
            karakterAnim.SetBool("yumruk", true);
            karakterAnim.SetBool("karakterRun", true);
            
            Invoke("animtekrar", 0.1f);
            dolarSayac += 50;
            
        }
        if (col.gameObject.tag == "dolar2")
        {
            if (kontrolTitresim == true)
            {
                MMVibrationManager.Haptic(hapticTypes3, false, true, this);
            }
            sesDogru.Play();
            col.gameObject.SetActive(false);
            Instantiate(efectDolar, efectOlusmaYeri.transform.position, Quaternion.identity);
            //col.gameObject.transform.parent = null;
            karakterAnim.SetBool("yumruk", true);
            karakterAnim.SetBool("karakterRun", true);
            Invoke("animtekrar", 0.1f);
            dolarSayac += 100;

        }
        if (col.gameObject.tag == "dolar3")
        {
            if (kontrolTitresim == true)
            {
                MMVibrationManager.Haptic(hapticTypes3, false, true, this);
            }
            sesDogru.Play();
            col.gameObject.SetActive(false);
            Instantiate(efectDolar, efectOlusmaYeri.transform.position, Quaternion.identity);
            //col.gameObject.transform.parent = null;
            karakterAnim.SetBool("yumruk", true);
            karakterAnim.SetBool("karakterRun", true);
            Invoke("animtekrar", 0.1f);
            dolarSayac += 150;

        }
    }
    
    
    void animtekrar()
    {
        //Map.GetComponent<mapdondurme>().kontrol = true;
        karakterAnim.SetBool("yumruk", false);
        
    }
    IEnumerator Kapat()
    {
        
        yield return new WaitForSeconds(0.3f);
        
    }
    
   

}
