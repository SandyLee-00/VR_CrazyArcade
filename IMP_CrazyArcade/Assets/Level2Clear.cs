using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Clear : MonoBehaviour
{
    public GameObject result;
    public GameObject resultPanel;
    public GameObject navigationPanel;
    public GameObject resultText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (result.GetComponent<getScore>().result == true)
        {
            StartCoroutine(scoreDelay());
            score = result.GetComponent<getScore>().score;
            resultText.GetComponent<Text>().text = "kill the " + score + "monster(s)!";
            resultPanel.SetActive(true);
            navigationPanel.SetActive(false);
        }
    }

    IEnumerator scoreDelay()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Ending");
    }
}
