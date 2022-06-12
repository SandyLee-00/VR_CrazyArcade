using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canbomb : MonoBehaviour
{
    public AudioClip collidesound;
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        audiosource.clip = collidesound;
        audiosource.Play();
        Destroy(other.gameObject);
    }

  
}
