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

    public GameObject player; //for get position 

    Vector3 pos;
    Vector3 BombPos;


    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
        pos = player.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, 0.0f, pos.z + 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.transform.position;
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
                BubbleBomb = Instantiate(BubbleBomb, new Vector3(pos.x, 0.0f, pos.z + 2.0f), Quaternion.identity);


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
                BubbleBomb = Instantiate(BubbleBomb, new Vector3(pos.x , 0.0f, pos.z+2.0f), Quaternion.identity);
        }
    }

    void active()
    {
        BubbleBomb.SetActive(true);
    }
}



