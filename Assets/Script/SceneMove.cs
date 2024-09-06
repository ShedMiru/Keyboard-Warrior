using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public GameObject ComingSoonWindow;
    // Start is called before the first frame update
    public void ToRoom1()
    {
        SceneManager.LoadScene("Room1");
    }

    public void ToRoom2()
    {
        SceneManager.LoadScene("Room2");
    }

    public void ToComingSoon()
    {
        GameObject CSW = (GameObject)Instantiate(ComingSoonWindow);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
