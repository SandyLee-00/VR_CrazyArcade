using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    GameObject temp;
    public AudioClip watersound;
    AudioSource audiosource;
    public GameObject BubbleBomb;
    public AudioClip collidesound2;

    //    public GameObject bubble;
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (OVRInput.Get(OVRInput.RawButton.A))
        {
        //    pos = Hand.transform.position;
            temp = Instantiate(BubbleBomb, new Vector3(pos.x, -0.41f, pos.z), Quaternion.identity);
         //   temp.transform.SetParent(bubble.transform);

            audiosource.clip = bubbleinititatesound;
            audiosource.Play();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block_Break"))
        {
            audiosource.clip = watersound;
            audiosource.Play();
            Destroy(other.gameObject);
            BubbleBomb.SetActive(!BubbleBomb.active);
            Invoke("active",2);
            audiosource.Play();

            BubbleBomb = Instantiate(BubbleBomb, new Vector3(0.244f, -0.36f, 1.32f), Quaternion.identity);

           

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audiosource.clip = watersound;
            audiosource.Play();
            Destroy(collision.gameObject);
            Destroy(BubbleBomb.gameObject);
            SceneManager.LoadScene("Level2");
        }
        else if (collision.gameObject.CompareTag("normalEnemy"))
        {
            audiosource.clip = watersound;
            audiosource.Play();
            Destroy(collision.gameObject);
            Invoke("active", 2);
            audiosource.Play();
        }
    }

    void active()
    {
        BubbleBomb.SetActive(true);
    }
}



