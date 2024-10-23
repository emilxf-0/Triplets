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
        //EventManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        EventManager.OnStartGame -= StartGame;
//        EventManager.OnGameOver -= GameOver;
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
        elementsDictionary[UIType.MainMenu].SetActive(false);
        elementsDictionary[UIType.HUD].SetActive(true);
        elementsDictionary[UIType.Tutorial].SetActive(false);
        elementsDictionary[UIType.GameOver].SetActive(false);
    }

    private void ShowMenu()
    {
        Time.timeScale = 0;
        elementsDictionary[UIType.MainMenu].SetActive(true);
        elementsDictionary[UIType.HUD].SetActive(false);
        elementsDictionary[UIType.Tutorial].SetActive(false);
        elementsDictionary[UIType.GameOver].SetActive(false);
    }

    public void RunTutorial()
    {
        Time.timeScale = 1;
        EventManager.StartTutorial();
        elementsDictionary[UIType.MainMenu].SetActive(false);
        elementsDictionary[UIType.HUD].SetActive(true);
        elementsDictionary[UIType.Tutorial].SetActive(true);
        elementsDictionary[UIType.GameOver].SetActive(false);
    }

    void OnGameOver()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        EventManager.RestartGame();
        SceneManager.LoadScene("Game");
    }

}
