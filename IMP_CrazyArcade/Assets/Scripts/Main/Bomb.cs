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
    public GameObject Effect;
    private GameObject spawnedEffect;
    public float x,y,z;

    Vector3 pos;
    Vector3 BombPos;


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

            //Particle Effect
            BombPos = this.BubbleBomb.transform.position;
            spawnedEffect = Instantiate(Effect, BombPos, Quaternion.identity);

            BubbleBomb.SetActive(!BubbleBomb.active);
            Invoke("active",2);
            audiosource.Play();

            if (BubbleBomb.activeSelf == false)
                BubbleBomb = Instantiate(BubbleBomb, new Vector3(x, y, z), Quaternion.identity);


            //Particle Effect Disapeear
            Destroy(spawnedEffect, 2f);

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

            //Particle Effect
            BombPos = this.BubbleBomb.transform.position;
            spawnedEffect = Instantiate(Effect, BombPos, Quaternion.identity);
            //Destroy(spawnedEffect, 2f);

            //Scene Change
            SceneManager.LoadScene("Level2");
        }


        else if (collision.gameObject.CompareTag("normalEnemy"))
        {
            audiosource.clip = watersound;
            audiosource.Play();

            //Disappear Enemy and Bomb
            Destroy(collision.gameObject);
            BubbleBomb.SetActive(!BubbleBomb.active);

            //Particle Effect
            BombPos = this.BubbleBomb.transform.position;
            spawnedEffect = Instantiate(Effect, BombPos, Quaternion.identity);
            Destroy(spawnedEffect, 2f);

            Invoke("active", 2);
            audiosource.Play();

            if (BubbleBomb.activeSelf == false)
                BubbleBomb = Instantiate(BubbleBomb, new Vector3(x, y, z), Quaternion.identity);
        }
    }

    void active()
    {
        BubbleBomb.SetActive(true);
    }
}



