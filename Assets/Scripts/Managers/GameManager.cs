using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action<GameState> onGameStateChanged;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
    }
    // void Start()
    // {
    //     changeState(GameState.GenerateGrid);
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeState(GameState newState) {
        GameState State = newState;

        switch (newState) {
            case GameState.GenerateGrid:
                break;
            case GameState.SelectCharacters:
                break;
            case GameState.SpawnEnemies:
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Victory:
                break;
            case GameState.Defeat:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
       }
       onGameStateChanged?.Invoke(newState);
    }
}
public enum GameState {
    GenerateGrid = 0,
    SelectCharacters = 1,
    SpawnEnemies = 2,
    PlayerTurn = 3,
    EnemyTurn = 4,
    Victory = 5,
    Defeat = 6
}
