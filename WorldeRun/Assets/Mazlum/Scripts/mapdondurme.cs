using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapdondurme : MonoBehaviour
{
    public float hiz;
    public bool kontrol = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kontrol==true)
        {
            transform.Rotate(Time.deltaTime * hiz, 0, 0);
        }
        
    }
}
