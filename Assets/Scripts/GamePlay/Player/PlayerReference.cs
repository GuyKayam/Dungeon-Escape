using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }
}
