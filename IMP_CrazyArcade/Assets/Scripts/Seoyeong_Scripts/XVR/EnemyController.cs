using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0F;

    public AudioClip losesound;
    AudioSource audiosource;
    // public AudioClip collidesound;
    // public AudioClip collidesound2;

    public bool isfollowing = true;

    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isfollowing == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }


        if (target.position == transform.position)
        {
            audiosource.clip = losesound;
            audiosource.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audiosource.clip = losesound;
            audiosource.Play();
        }
    }
}
