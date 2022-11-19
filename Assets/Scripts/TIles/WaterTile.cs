using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : GridTile
{
    public override void Init()
    {
        base.Init();
        elevation = -1;
    }
}