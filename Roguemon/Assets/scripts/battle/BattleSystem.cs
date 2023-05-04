using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState{start, PlayerAction,PlayerMove,EnemyMove, Busy}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] battleUnit PlayerUnit;
    [SerializeField] battleHud PlayerHud;

    [SerializeField] battleUnit EnemyUnit;
    [SerializeField] battleHud EnemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    public event Action<bool> onBattleOver;

    BattleState state;
    int currentAction;
    int currentMove;

private void Start() {
    StartCoroutine(SetupBattle());
}
public IEnumerator SetupBattle(){
    PlayerUnit.Setup();
    PlayerHud.setData(PlayerUnit.Pokemon);

    EnemyUnit.Setup();
    EnemyHud.setData(EnemyUnit.Pokemon);

    dialogBox.SetMoveNames(PlayerUnit.Pokemon.Moves);

    yield return dialogBox.TypeDialog($"A wild {EnemyUnit.Pokemon.Base.Name} appeared.");
    yield return new WaitForSeconds(1f);

    PlayerAction();
}

void PlayerAction(){
    state = BattleState.PlayerAction;
   StartCoroutine(dialogBox.TypeDialog("choose an action"));
   dialogBox.EnableActionSelector(true);
}
void PlayerMove(){
    state = BattleState.PlayerMove;
   dialogBox.EnableActionSelector(false);
   dialogBox.EnableDialogText(false);
   dialogBox.EnableMoveSelector(true);
}

//IEnumerator performePlayerMove(){

   // var move = PlayerUnit.Pokemon.Moves[currentMove];
   // yield return dialogBox.TypeDialog($"{pl}")
//}

public void HandleUpdate() {
    if(state == BattleState.PlayerAction){
        HandleActionSelection();
    }
    else if(state == BattleState.PlayerMove){
        HandleMoveSelection();
    }
}

void HandleActionSelection(){
    if(Input.GetKeyDown(KeyCode.DownArrow)){
        if(currentAction < 1)
            ++currentAction;
    }
    else if(Input.GetKeyDown(KeyCode.UpArrow)){
        if(currentAction > 0)
            --currentAction;
    }

    dialogBox.UpdateActionSelection(currentAction);


    if(Input.GetKeyDown(KeyCode.Return)){
        if(currentAction == 0){
            PlayerMove();
        }
        else if(currentAction == 1){

        }
            
    }
}

void HandleMoveSelection(){
   if(Input.GetKeyDown(KeyCode.RightArrow)){
        if(currentMove < PlayerUnit.Pokemon.Moves.Count - 1)
            ++currentMove;
    }
    else if(Input.GetKeyDown(KeyCode.LeftArrow)){
        if(currentMove > 0)
            --currentMove;
    } 
    if(Input.GetKeyDown(KeyCode.DownArrow)){
        if(currentMove < PlayerUnit.Pokemon.Moves.Count - 2)
            currentMove += 2;
    }
    else if(Input.GetKeyDown(KeyCode.UpArrow)){
        if(currentMove > 1)
            currentMove -= 2;
    }

    dialogBox.UpdateMoveSelection(currentMove,PlayerUnit.Pokemon.Moves[currentMove]);
    if(Input.GetKeyDown(KeyCode.Return)){
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(true);
        //StartCoroutine(performePlayerMove());
    }
}

}