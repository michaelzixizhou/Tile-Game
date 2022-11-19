using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTile : GridTile
{
    public override void Init()
    {
        base.Init();
        elevation = -2;
    }
}
