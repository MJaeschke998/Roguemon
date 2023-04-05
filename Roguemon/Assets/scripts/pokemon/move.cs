using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move
{
    public moveBase Base { get; set; }
    public int PP { get; set; }

    public move(moveBase pBase){
        Base = pBase;
        PP = pBase.PP;
    }
}
