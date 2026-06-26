using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "DeteccionPlayer", story: "Player is in vision", category: "Conditions", id: "b842b974de8ce9100470aadd34e13501")]
public partial class DeteccionPlayerCondition : Condition
{

    public override bool IsTrue()
    {
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
