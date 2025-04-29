using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject menuButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        mainMenu.SetActive(true);
        credits.SetActive(false);
        menuButton.SetActive(false);
    }

    public void OpenPsycheScene()
    {
        Debug.Log("open called");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Scene scene = SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(scene.name);
    }

    public void openMenu()
    {
        Debug.Log("Opening menu");
        mainMenu.SetActive(true);
        credits.SetActive(false);
        menuButton.SetActive(false);
    }

    public void openCredits()
    {
        Debug.Log("Open credits");
        credits.SetActive(true);
        mainMenu.SetActive(false);
        menuButton.SetActive(false);
    }

    public void showMenuButton()
    {
        menuButton.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
