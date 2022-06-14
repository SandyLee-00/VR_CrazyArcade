using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject creditPanel;

    public void level1ButtonEvent()
    {
        Debug.Log("click button1");
        SceneManager.LoadScene("Playmain");
    }

    public void level2ButtonEvent()
    {
        Debug.Log("click button2");
        SceneManager.LoadScene("Playmain");
    }

    public void homeButtonEvent()
    {
        mainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    public void tutorialButtonEvent()
    {
        mainPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void creditButtonEvent()
    {
        mainPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        creditPanel.SetActive(true);
    }
}
