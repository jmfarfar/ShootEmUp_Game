using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadScene("Luna");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
