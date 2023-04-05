using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleUnit : MonoBehaviour
{
    [SerializeField] pokemonBase _Base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon { get; set;}
    public void Setup(){
       Pokemon = new Pokemon(_Base,level);
       if(isPlayerUnit){
       GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
       }
       else{
        GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
        
       }
    }

}
