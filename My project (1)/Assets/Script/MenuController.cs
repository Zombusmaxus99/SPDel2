using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelMenu;

    public void StartGame() //No longer nececary as it only loads one scene and LoadLevel is more flexible
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect() //Disables regular menu and enables level menu
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void ReturnToMain() //Disables level menu and enables main menu
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void LoadLevel(int sceneNumber) //Opens scene: sceneNumber
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits() 
    {
        creditsPanel.SetActive(false);
    }
 }
