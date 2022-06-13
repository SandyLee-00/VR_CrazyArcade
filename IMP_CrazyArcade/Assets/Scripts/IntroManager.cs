using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(IntroDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IntroDelay()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("ChooseLevel");
    }

}
