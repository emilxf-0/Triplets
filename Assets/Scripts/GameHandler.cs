using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [Serializable]
    public class UIElement
    {
        public UIType elementType;
        public GameObject gameObject;
    }

    [SerializeField] private List<UIElement> UIElements = new();
    private Dictionary<UIType, GameObject> elementsDictionary = new();

    public enum UIType
    {
        MainMenu,
        Tutorial,
        HUD,
        GameOver,
    };

    private void OnEnable()
    {
        EventManager.OnStartGame += StartGame;
        EventManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        EventManager.OnStartGame -= StartGame;
        EventManager.OnGameOver -= GameOver;
    }

    void Start()
    {
        foreach (UIElement element in UIElements)
        {
            if (!elementsDictionary.ContainsKey(element.elementType))
            {
                elementsDictionary.Add(element.elementType, element.gameObject);
            }
            else
            {
                Debug.LogWarning($"{element.elementType} already exists");
            }
        }

        ShowMenu();

    }

    public void StartGame()
    {
        Time.timeScale = 1;
        ActivateUI(UIType.HUD); 
    }

    private void ShowMenu()
    {
        Time.timeScale = 0;
        ActivateUI(UIType.MainMenu);
    }

    public void RunTutorial()
    {
        Time.timeScale = 1;
        EventManager.StartTutorial();
        ActivateUI(UIType.HUD, UIType.Tutorial);
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        EventManager.RestartGame();
        SceneManager.LoadScene("Game");
    }

    void ActivateUI(UIType key)
    {
        foreach (KeyValuePair<UIType, GameObject> type in elementsDictionary)
        {
            if (type.Key == key)
            {
                elementsDictionary[type.Key].SetActive(true);
            }
            else    
            {
                elementsDictionary[type.Key].SetActive(false);
            }
        }
    }

    void ActivateUI(UIType key, UIType key2)
    {
        foreach (KeyValuePair<UIType, GameObject> type in elementsDictionary)
        {
            if (type.Key == key || type.Key == key2)
            {
                elementsDictionary[type.Key].SetActive(true);
            }
            else
            {
                elementsDictionary[type.Key].SetActive(false);
            }
        }
    }

}
