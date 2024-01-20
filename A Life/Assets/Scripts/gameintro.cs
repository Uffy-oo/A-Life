using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameintro: MonoBehaviour
{
    public Text introText;
    public Button startButton;

    private string[] introLines = {
        "Welcome to 'A' Life, a journey through the hallowed halls of McGill.",
        "In this 2D RPG game, you will paly as a student, navigating the challenges of university life.",
        "From assignments to networking, every decision you make shapes your future.",
        "Complete mini-games to boost your abilities. It will determine your path.",
        "But be careful, for each misstep can lead towards a future less bright.",
        "Can you achieve your dreams and secure a promising future?",
        "Your journey begins now!"
    };

    private int currentLine = 0;

    void Start()
    {
        introText.text = introLines[currentLine];
        startButton.onClick.AddListener(NextLine);
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine < introLines.Length)
        {
            introText.text = introLines[currentLine];
        }
        else
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("MainGameScene");
    }
}
