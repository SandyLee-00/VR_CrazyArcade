using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject temp;
    public AudioClip collidesound;
    AudioSource audiosource;
    public GameObject BubbleBomb;
    public GameObject Hand;
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            // pos = Hand.transform.position;
            // temp = Instantiate(BubbleBomb, new Vector3(pos.x, -0.41f, pos.z), Quaternion.identity);
            
            BubbleBomb.SetActive(false);
        }
        
        else if (OVRInput.Get(OVRInput.RawButton.B))
        {
            // pos = Hand.transform.position;
            // temp = Instantiate(BubbleBomb, new Vector3(pos.x, -0.41f, pos.z), Quaternion.identity);


            BubbleBomb.SetActive(true); //Not working

        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block_Break"))
        {
            audiosource.clip = collidesound;
            audiosource.Play();
            Destroy(other.gameObject);

        }
    }

    void PressButton()
    {
        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            // setActive Bubble
          //  pos = Hand.transform.position;
           // temp = Instantiate(BubbleBomb, new Vector3(pos.x, -0.41f, pos.z), Quaternion.identity);
            BubbleBomb.SetActive(!BubbleBomb);
        }
    }




}



