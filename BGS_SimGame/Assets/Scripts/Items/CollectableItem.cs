using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public CollectableType collectableType;
    public Sprite icon;
}

public enum CollectableType
{
    NONE,
    PUMPKIN,
    CARROT,
    PEACH
}
