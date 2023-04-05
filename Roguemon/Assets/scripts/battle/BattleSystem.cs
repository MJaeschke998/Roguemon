using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] battleUnit PlayerUnit;
    [SerializeField] battleHud PlayerHud;

    [SerializeField] battleUnit EnemyUnit;
    [SerializeField] battleHud EnemyHud;

private void Start() {
    SetupBattle();
}
public void SetupBattle(){
    PlayerUnit.Setup();
    PlayerHud.setData(PlayerUnit.Pokemon);

    EnemyUnit.Setup();
    EnemyHud.setData(EnemyUnit.Pokemon);
}
}