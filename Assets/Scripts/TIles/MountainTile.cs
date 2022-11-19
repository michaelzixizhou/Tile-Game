using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainTile : GridTile
{
    public override void Init()
    {
        base.Init();
        elevation = 2;
    }
}
