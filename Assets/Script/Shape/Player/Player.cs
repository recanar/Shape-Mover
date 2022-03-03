using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Shape
{
    public override abstract void GiveColor();
    public abstract Vector3 MovePlayer();
    public abstract Vector3 Jump();
}
