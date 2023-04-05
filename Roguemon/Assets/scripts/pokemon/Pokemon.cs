using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon 
{
    public pokemonBase Base {get; set;}
    public int Level {get; set;}

    public int HP {get; set;}

    public List<move> Moves {get; set;}

    public Pokemon(pokemonBase pBase, int pLevel){

       Base = pBase;
        Level = pLevel;
        HP = MaxHp;


        Moves = new List<move>();
        
        foreach (var move in Base.LearnableMoves)
        {
            if(move.Level <= Level){
                Moves.Add(new move(move.Base));

                if(Moves.Count >= 4)
                break;
            }
        }
    }

    public int MaxHp{
      get{ return Mathf.FloorToInt( (Base.Attack * Level) / 100f) +10; }  
    }
    public int Attack{
      get{ return Mathf.FloorToInt( (Base.Attack * Level) / 100f) +5; }  
    }
    public int Defence{
      get{ return Mathf.FloorToInt( (Base.Attack * Level) / 100f) +5; }  
    }
    public int SpAttack{
      get{ return Mathf.FloorToInt( (Base.Attack * Level) / 100f) +5; }  
    }
    public int SpDefence{
      get{ return Mathf.FloorToInt( (Base.Attack * Level) / 100f) +5; }  
    }
    public int Speed{
      get{ return Mathf.FloorToInt( (Base.Attack * Level) / 100f) +5; }  
    }
}
