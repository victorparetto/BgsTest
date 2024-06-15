using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractableType
    {
        NONE,
        DOOR,
        SHOP,
        CHEST,
        BOOKCASE,
        BED
    }
    public InteractableType interactableType;

    public bool immediateInteraction = false;
    //Door enum uses
    public Vector2 endPos;
}
