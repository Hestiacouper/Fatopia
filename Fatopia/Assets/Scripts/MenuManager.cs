using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] GameObject panelMenuPause;
    [SerializeField] GameObject panelMenuWin;
    [SerializeField] GameObject panelMainMenu;
    [SerializeField] String reloadScene;
    void Start()
    {
        LoadMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (panelMenuPause.activeSelf)
            {
                UnloadMenuPause();
            }
            else
            {
                LoadMenuPause();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }
    }


    public void LoadMainMenu()
    {
        panelMainMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnloadMainMenu()
    {
        panelMainMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void LoadMenuPause()
    {
        panelMenuPause.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnloadMenuPause()
    {
        panelMenuPause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadMenuWin()
    {
        panelMenuWin.gameObject.SetActive(true); 
        Time.timeScale = 0;
    }

    public void UnloadMenuWin()
    {
        panelMenuWin.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void Retry()
    {
        //please don't forget to make this func later future me
        SceneManager.LoadScene(reloadScene);
    }
}
