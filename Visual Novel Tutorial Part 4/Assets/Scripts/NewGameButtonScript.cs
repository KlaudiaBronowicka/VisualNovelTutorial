using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButtonScript : MonoBehaviour
{
    GameStateManager _gameStateManager;
    void Start()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();

        if (_gameStateManager == null)
        {
            Debug.LogError("Game State Manager was not found!");
        }
    }

    public void OnClick()
    {
        _gameStateManager?.StartGame();
    }
}
