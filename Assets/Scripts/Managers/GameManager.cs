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
    public GameState gameState;
    // public static event Action<GameState> onGameStateChanged;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        changeState(GameState.GenerateGrid);
        // print(UnitManager.instance.GetUnit("Gorilla").GetComponent<Gorilla>().curr_health);
    }
    private void Update() {
        /// Press space bar to change between turns
        if (gameState == GameState.PlayerTurn){
            if (Input.GetKeyDown(KeyCode.Space)){
                changeState(GameState.EnemyTurn);
            }
        } else if (gameState == GameState.EnemyTurn){
            if (Input.GetKeyDown(KeyCode.Space)){
                changeState(GameState.PlayerTurn);
            }
        }
    }

    /// <summary>
    /// changeState will be called by other managers to change game state.
    /// Add GameStates here and method calls under the case to handle logic.
    /// </summary>
    /// <param name="newState"></param>
    /// <exception cref="ArgumentOutOfRangeException">GameState out of range</exception>
    public void changeState(GameState newState) {
        gameState = newState;

        switch (newState) {
            case GameState.GenerateGrid:
                GridManager.instance.GenerateGrid();
                changeState(GameState.SpawnEnemies);
                // Generates the grid
                break;
            case GameState.SelectCharacters:
                break;
            case GameState.SpawnEnemies:
                // spawn and add characters to teams
                UnitManager.instance.TestSpawn();

                PlayerTeam t1 = TeamManager.instance.GetPlayerTeam();
                t1.AddUnit(UnitManager.instance.GetUnit("Monkey"));
                t1.AddUnit(UnitManager.instance.GetUnit("Toucan"));

                EnemyTeam t2 = TeamManager.instance.GetEnemyTeam();
                t2.AddUnit(UnitManager.instance.GetUnit("Cow"));
                t2.AddUnit(UnitManager.instance.GetUnit("Gorilla"));

                t1.ToggleMovement();
                changeState(GameState.PlayerTurn);
                break;
            case GameState.PlayerTurn:
                TeamManager.instance.ChangeTurn();
                break;
            case GameState.EnemyTurn:
                TeamManager.instance.ChangeTurn();
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
