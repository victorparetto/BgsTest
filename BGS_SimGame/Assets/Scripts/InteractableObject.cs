using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool immediateInteraction = false;

    public enum InteractableType
    {
        NONE,
        DOOR,
        SHOP_ITEM,
        CHEST,
        BOOKCASE,
        BED
    }
    public InteractableType interactableType;


    //Door enum variables
    public Vector2 endPos;

    //Shop_Item enum variables
    public Animator anim;

    //Chest enum variables
    public SpriteRenderer sr;
    public Sprite[] sprites; //0 = closed, 1 = open

    void OnTriggerEnter2D(Collider2D other)
    {
        if (interactableType == InteractableType.SHOP_ITEM)
        {
            if (other.CompareTag("Player"))
            {
                anim.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (interactableType == InteractableType.SHOP_ITEM)
        {
            if (other.CompareTag("Player"))
            {
                anim.enabled = false;
            }
        }
    }
}
