using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Collectables : ScriptableObject
{
    new public string name = "New Item";

    public Sprite icon = null;

    public bool isDefaultItem = false;
}
