using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerScript : ScenesInMenu
{
    private void OnTriggerEnter(Collider other)
    {
        VictoryScene();
    }
}
