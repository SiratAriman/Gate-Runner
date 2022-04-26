using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTriggerCheck : MonoBehaviour
{
    [HideInInspector]
    public bool IsTrigerred = false;

    public void SetTriggered()
    {
        IsTrigerred = true;
    }

}