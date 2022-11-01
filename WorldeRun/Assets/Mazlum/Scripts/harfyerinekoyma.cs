using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harfyerinekoyma : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject HarfSpawnlama;
    GameObject kelime;
    GameObject Karakter;
    void Start()
    {
        HarfSpawnlama = GameObject.FindGameObjectWithTag("map");
        for (int i = 0; i < HarfSpawnlama.GetComponent<harfspawnlama>().kelimeObject.Length; i++)
        {
            kelime = HarfSpawnlama.GetComponent<harfspawnlama>().kelimeObject[i];
            kelime.SetActive(true);
        }
        Karakter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        
        //for (int i = 0; i < HarfSpawnlama.GetComponent<harfspawnlama>().kelimeObject.Length; i++)
        //{
        //    if (col.gameObject.tag == "Player")
        //    {

        //        for (int j = 0; j < HarfSpawnlama.GetComponent<harfspawnlama>().kelimeObject.Length; j++)
        //        {
        //            Karakter.GetComponent<karakterhareket>().karakterAnim.SetBool("yumruk", false);
        //            if (gameObject.name == HarfSpawnlama.GetComponent<harfspawnlama>().kelimeObject[j].name)
        //            {
        //                gameObject.SetActive(false);
        //                Karakter.GetComponent<karakterhareket>().karakterAnim.SetBool("yumruk", true);
        //                //kelime.SetActive(true);
        //                //this.gameObject.transform.parent = kelime.transform;
        //                //Instantiate(kelime, transform.position, transform.rotation);
        //                //transform.position = Vector3.Lerp(kelime.transform.position, GameObject.Find("G").transform.position, 1f);
                       
                        
        //            }
        //        }

                    
                
                
                
        //    }
        //}

    }
}
