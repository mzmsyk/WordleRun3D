using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harfspawnlama : MonoBehaviour
{
    
    public float spZamani, spGecikmesi;
    public float spZamani2, spGecikmesi2;
    public float spZamani3, spGecikmesi3;
    public GameObject[] kelimeObject;
    public GameObject[] kelimeObject2;
    public GameObject[] kelimeObject3;
    public GameObject dolarObject;
    public GameObject dolarObject2;
    public GameObject dolarObject3;
    int sayac=0;
    int sayac2 = 0;
    int sayac3 = 0;
    int sayac4 = 0;
    public Transform baslangic;
    public Transform baslangic2;
    public Transform baslangicDolar;
    public Transform baslangicDolar2;
    public Transform baslangicDolar3;
    public Transform baslangicDolar4;
    public Transform baslangicDolar5;
    public Transform baslangicDolar6;
    public Transform baslangicDolar7;
    public Transform baslangicDolar8;
    public Transform baslangicDolar9;
    GameObject Karakter;
    GameObject OyunYoneticisi;
    public bool kontrol;
    public bool kontrol2;
    public bool kontrolSinir=true;
    public bool kontrolSinir2 = true;

    void Start()
    {
        Karakter = GameObject.FindGameObjectWithTag("Player");
        kontrol = false;
        kontrol2 = false;
        OyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisi");
        kontrol = false;
        OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrolLetter = false;
        OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrolChange = false;



    }

    
    void Update()
    {
        if (kontrol==true)
        {
            InvokeRepeating("Spawnn", spZamani, spGecikmesi);
            InvokeRepeating("Spawnn2", spZamani2, spGecikmesi2);
            InvokeRepeating("SpawnDolar", spZamani3, spGecikmesi3);
            InvokeRepeating("SpawnDolar2", spZamani3, spGecikmesi3);
            InvokeRepeating("SpawnDolar3", spZamani3, spGecikmesi3);

            kontrol = false;
        }
        if (kontrol2==true)
        {
            InvokeRepeating("SpawnnKlon", spZamani, spGecikmesi);
            InvokeRepeating("Spawnn2", spZamani2, spGecikmesi2);
            InvokeRepeating("SpawnDolar", spZamani3, spGecikmesi3);
            InvokeRepeating("SpawnDolar2", spZamani3, spGecikmesi3);
            InvokeRepeating("SpawnDolar3", spZamani3, spGecikmesi3);
            kontrol2 = false;
        }
        if (Input.GetMouseButtonDown(0)&&kontrol==true)
        {
            
        }
        if (OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrol == true)
        {
            kelimeObject[OyunYoneticisi.GetComponent<oyunyoneticisi>().rastgeleDeger].SetActive(false);
            
        }
        
    }
    
    public void Spawnn()
    {
        
            
        if (OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrolLetter == true)
        {
            GameObject kelime = Instantiate(kelimeObject[sayac], baslangic.position, Quaternion.Euler(0, 0, 0));
            kelime.transform.parent = this.gameObject.transform;
            kelime.name = kelimeObject[sayac].name;
            sayac++;
            kontrolSinir = true;
            kontrolSinir2 = true;
            if (OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrol == true)
            {
                kelimeObject[OyunYoneticisi.GetComponent<oyunyoneticisi>().rastgeleDeger].SetActive(false);

            }
            if (kelimeObject.Length == sayac)
            {
                CancelInvoke("Spawnn");
                sayac = 0;
                
            }
        }
            
        
            
            
        
        
        
    }
    public void SpawnnKlon()
    {

        
        

        if (OyunYoneticisi.GetComponent<oyunyoneticisi>().kontrolChange==true)
        {
            GameObject kelime = Instantiate(kelimeObject3[sayac3], baslangic.position, Quaternion.Euler(0, 0, 0));
            kelime.transform.parent = this.gameObject.transform;
            kelime.name = kelimeObject3[sayac3].name;
            kelime.SetActive(true);
            sayac3++;
            if (kelimeObject3.Length == sayac3)
            {
            CancelInvoke("SpawnnKlon");
            sayac3 = 0;
            
            }
        }
        
        
        



    }
    public void Spawnn2()
    {
      
                GameObject kelime = Instantiate(kelimeObject2[sayac2], baslangic2.position, Quaternion.Euler(0, 0, 0));
                kelime.transform.parent = this.gameObject.transform.GetChild(2);
                kelime.name = kelimeObject2[sayac2].name;
                sayac2++;
                kontrolSinir = false;
                if (kelimeObject2.Length == sayac2)
                {
                    //CancelInvoke("Spawnn2");
                    sayac2 = 0;
                    kontrolSinir = true;
                    
                }
        
        
        

    }
    public void SpawnDolar()
    {
      
                GameObject kelime = Instantiate(dolarObject, baslangicDolar.position, Quaternion.Euler(-70, 0, 0));
                kelime.transform.parent = this.gameObject.transform.GetChild(2);
                kelime.name = dolarObject.name;
                sayac4++;
        GameObject kelime2 = Instantiate(dolarObject2, baslangicDolar2.position, Quaternion.Euler(-70, 0, 0));
        kelime2.transform.parent = this.gameObject.transform.GetChild(2);
        kelime2.name = dolarObject2.name;
        GameObject kelime3 = Instantiate(dolarObject3, baslangicDolar3.position, Quaternion.Euler(-70, 0, 0));
        kelime3.transform.parent = this.gameObject.transform.GetChild(2);
        kelime3.name = dolarObject3.name;
        sayac4++;
       


    }
    public void SpawnDolar2()
    {
        
        GameObject kelime = Instantiate(dolarObject, baslangicDolar4.position, Quaternion.Euler(-80, 0, 0));
        kelime.transform.parent = this.gameObject.transform.GetChild(2);
        kelime.name = dolarObject.name;
        sayac4++;
        GameObject kelime2 = Instantiate(dolarObject2, baslangicDolar5.position, Quaternion.Euler(-80, 0, 0));
        kelime2.transform.parent = this.gameObject.transform.GetChild(2);
        kelime2.name = dolarObject2.name;
        GameObject kelime3 = Instantiate(dolarObject3, baslangicDolar6.position, Quaternion.Euler(-80, 0, 0));
        kelime3.transform.parent = this.gameObject.transform.GetChild(2);
        kelime3.name = dolarObject3.name;
        


    }
    public void SpawnDolar3()
    {
       
        GameObject kelime = Instantiate(dolarObject, baslangicDolar7.position, Quaternion.Euler(-90, 0, 0));
        kelime.transform.parent = this.gameObject.transform.GetChild(2);
        kelime.name = dolarObject.name;
        sayac4++;
        GameObject kelime2 = Instantiate(dolarObject2, baslangicDolar8.position, Quaternion.Euler(-90, 0, 0));
        kelime2.transform.parent = this.gameObject.transform.GetChild(2);
        kelime2.name = dolarObject2.name;
        GameObject kelime3 = Instantiate(dolarObject3, baslangicDolar9.position, Quaternion.Euler(-90, 0, 0));
        kelime3.transform.parent = this.gameObject.transform.GetChild(2);
        kelime3.name = dolarObject3.name;
        sayac4++;
       


    }
    
}
