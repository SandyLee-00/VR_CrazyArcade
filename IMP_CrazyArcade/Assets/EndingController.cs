using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public void backmMainEvent()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
}
