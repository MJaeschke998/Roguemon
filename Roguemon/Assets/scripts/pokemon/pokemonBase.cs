using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon",menuName = "Pokemon/Create new pokemon")]

public class pokemonBase : ScriptableObject{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;


    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defence;
    [SerializeField] int spAttack;
    [SerializeField] int spDefence;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;


    public string Name{
        get {return name;}
    }
    public string Description{
        get {return description;}
    }
    public Sprite FrontSprite{
        get {return frontSprite;}
    }
    public Sprite BackSprite{
        get {return backSprite;}
    }
    public PokemonType Type1{
        get {return type1;}
    }
     public PokemonType Type2{
        get {return type2;}
    }
    public int MaxHp{
        get {return maxHP;}
    }
    public int Attack{
        get {return attack;}
    }
    public int Defence{
        get {return defence;}
    }
    public int SpAttack{
        get {return spAttack;}
    }
    public int SpDefence{
        get {return spDefence;}
    }
    public int Speed{
        get {return speed;}
    }
    public List<LearnableMove> LearnableMoves{
        get{ return learnableMoves; }
    }


}
[System.Serializable]
public class LearnableMove{
    [SerializeField] moveBase moveBase;
    [SerializeField] int level;

    public moveBase Base{
        get {return moveBase;}
    
    }
    public int Level{
        get {return level;}
    }
}

public enum PokemonType{

    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighing,
    Poison,
    Ground,
    Flying,
    Physic,
    Bug,
    Rock,
    Ghost,
    Dragon

}