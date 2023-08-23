using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        TTPCore.Setup();
    }
}
