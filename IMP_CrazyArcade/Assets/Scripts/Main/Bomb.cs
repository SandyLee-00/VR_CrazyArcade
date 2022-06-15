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
    public GameObject resultYN;

    Vector3 pos;
    Vector3 BombPos;

    private bool getBomb;


    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
        pos = player.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, 1.07f, pos.z + 2.0f);
        getBomb = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.transform.position;
        if(!getBomb)
        {
            BubbleBomb.transform.position = new Vector3(pos.x, 1.07f, pos.z + 2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        getBomb = true;
        if (other.CompareTag("Block_Break"))
        {
            audiosource.clip = watersound;
            audiosource.Play();
            Destroy(other.gameObject);

            //Particle Effect
            BombPos = this.BubbleBomb.transform.position;
            spawnedEffect = Instantiate(Effect, BombPos, Quaternion.identity);

            BubbleBomb.SetActive(!BubbleBomb.active);
            Invoke("active",1);
            audiosource.Play();

            if (BubbleBomb.activeSelf == false)
                BubbleBomb = Instantiate(BubbleBomb, new Vector3(pos.x, 1.07f, pos.z + 2.0f), Quaternion.identity);


            //Particle Effect Disapeear
            Destroy(spawnedEffect, 2f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        getBomb = true;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            resultYN.GetComponent<getScore>().score += 1;
            audiosource.clip = watersound;
            audiosource.Play();
            Destroy(collision.gameObject);
            Destroy(BubbleBomb.gameObject);

            //Particle Effect
            BombPos = this.BubbleBomb.transform.position;
            spawnedEffect = Instantiate(Effect, BombPos, Quaternion.identity);
            Destroy(spawnedEffect, 2f);

            //Scene Change
            //SceneManager.LoadScene("Level2");
            if (resultYN.GetComponent<getScore>().result == false)
                resultYN.GetComponent<getScore>().result = true;
        }


        else if (collision.gameObject.CompareTag("normalEnemy"))
        {
            resultYN.GetComponent<getScore>().score += 1;
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
                BubbleBomb = Instantiate(BubbleBomb, new Vector3(pos.x , 1.07f, pos.z+2.0f), Quaternion.identity);
        }
    }

    void active()
    {
        BubbleBomb.SetActive(true);
    }
}



