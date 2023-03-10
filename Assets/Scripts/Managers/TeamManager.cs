using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;
    [SerializeField] private PlayerTeam playerteam;
    [SerializeField] private EnemyTeam enemyteam;
    public int whos_turn = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        // playerteam = this.GetComponent<PlayerTeam>();
        // enabled = this.GetComponent<EnemyTeam>();
    }

    // public void Init() {
    //     all_teams[whos_turn].ToggleMovement();
    // }

    /// <summary>
    /// Change turns between Player and Enemy.
    /// </summary>
    public void ChangeTurn(){
        playerteam.ToggleMovement();
        enemyteam.ToggleMovement();
    }


    // public void ChangeTurn(int team){
    //     if (team == 0){
    //         playerteam.ToggleMovement();
    //     } else if (team == 1){
    //         enemyteam.ToggleMovement();
    //     }
    // }

    /// <summary>
    /// Getter function for EnemyTeam.
    /// </summary>
    /// <returns>EnemyTeam</returns>
    public EnemyTeam GetEnemyTeam(){
        return enemyteam;
    }

    /// <summary>
    /// Getting function for PlayerTeam.
    /// </summary>
    /// <returns>PlayerTeam</returns>
    public PlayerTeam GetPlayerTeam(){
        return playerteam;
    }
}
