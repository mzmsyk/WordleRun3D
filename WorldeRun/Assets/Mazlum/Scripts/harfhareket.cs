using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harfhareket : MonoBehaviour
{
    GameObject harf;
    public bool kontrol = false;
    void Start()
    {
        harf = GameObject.FindGameObjectWithTag(this.gameObject.name);
    }

    
    void Update()
    {
        if (kontrol==true)
        {
            transform.position = Vector3.Lerp(transform.position, harf.transform.position, 5f*Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Player")
        {
            kontrol = true;
        }
    }
}
