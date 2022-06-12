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

    private bool isfollowing = true;

    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if(target.position == transform.position)
        {
            audiosource.clip = losesound;
            audiosource.Play();
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audiosource.clip = collidesound;
            audiosource.Play();
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Level2");

        }else if (collision.gameObject.CompareTag("normalEnemy"))
        {
            audiosource.clip = collidesound2;
            audiosource.Play();
            Destroy(collision.gameObject);
        }
    }
    */
}
