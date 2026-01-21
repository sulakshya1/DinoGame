using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OpeaningScreen : MonoBehaviour
{
    public GameObject opeaningScreen;
    public Button startButton;
    public Button quitButton;
    public Spawnner spawnner;

    void Start()
    {
        spawnner = FindFirstObjectByType<Spawnner>();
        spawnner.gameObject.SetActive(false);
        GameManager.instance.enabled = false;
        startButton.onClick.AddListener(OnStartGame);
        if (quitButton != null)
            quitButton.onClick.AddListener(() => Application.Quit());
    }

    private void OnStartGame()
    {
        opeaningScreen.SetActive(false);
        GameManager.instance.enabled = true;
        GameManager.instance.NewGame();
    }
}

