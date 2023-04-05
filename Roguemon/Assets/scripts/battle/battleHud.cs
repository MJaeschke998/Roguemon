using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text lvlText;
    [SerializeField] hpBar hpBar;

    public void setData(Pokemon pokemon){
        nameText.text = pokemon.Base.Name;
        lvlText.text = "Lvl " + pokemon.Level;
        hpBar.SetHP((float) pokemon.HP / pokemon.MaxHp);
    }
}
