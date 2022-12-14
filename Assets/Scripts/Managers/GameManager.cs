using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
GameManager will handle switching game states as the overarching controller

Other Managers will call GameManager.Instance.ChangeState() to advance the game
*/
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public static event Action<GameState> onGameStateChanged;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        // UnitManager.instance.TestSpawn();
        GridManager.instance.GenerateGrid();
        // print(UnitManager.instance.GetUnit("Gorilla").GetComponent<Gorilla>().curr_health);
    }

    // void Start()
    // {
    //     changeState(GameState.GenerateGrid);
    // }


    /// <summary>
    /// changeState will be called by other managers to change game state.
    /// Add GameStates here and method calls under the case to handle logic.
    /// </summary>
    /// <param name="newState"></param>
    /// <exception cref="ArgumentOutOfRangeException">GameState out of range</exception>
    public void changeState(GameState newState) {
        GameState State = newState;

        switch (newState) {
            case GameState.GenerateGrid:
                // can add methods here for example
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
                // throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
                break;
        }

    //    onGameStateChanged?.Invoke(newState);
    }
}

/*
This creates unchangeable variables as part of GameState, and it can be referred to
by using GameState.InsertState
*/
public enum GameState {
    GenerateGrid = 0,
    SelectCharacters = 1,
    SpawnEnemies = 2,
    PlayerTurn = 3,
    EnemyTurn = 4,
    Victory = 5,
    Defeat = 6
}
