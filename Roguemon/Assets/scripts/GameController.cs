using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{FreeRoam,Battle}


public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement PlayerMovement;
    [SerializeField] BattleSystem BattleSystem;
    [SerializeField] Camera worldCamera;
    GameState state;

    private void Start(){
        PlayerMovement.onEncounterd += StartBattle;
    }
    void StartBattle(){
        state = GameState.Battle;
        BattleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

    }

    private void Update(){
        if(state == GameState.FreeRoam){

            PlayerMovement.HandleUpdate();

        }
        else if(state == GameState.Battle){
            BattleSystem.HandleUpdate();
        }
    }
}
