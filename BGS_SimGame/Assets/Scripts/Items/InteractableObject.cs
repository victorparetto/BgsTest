using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool immediateInteraction = false;

    public enum InteractableType
    {
        NONE,
        DOOR,
        SHOP_UNLOCKABLE,
        SHOP_ITEM,
        CHEST,
        BOOKCASE,
        BED
    }
    public InteractableType interactableType;


    //Door enum variables
    public Vector2 endPos;

    //Shop_Unlockable enum variables
    public Animator anim;
    public Unlockable unlockable;

    //Chest enum variables
    public int coinsToAdd = 0;
    public SpriteRenderer sr;
    public Sprite[] sprites; //0 = closed, 1 = open
    public GameObject chestContent = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (interactableType == InteractableType.SHOP_UNLOCKABLE)
        {
            if (other.CompareTag("Player"))
            {
                anim.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (interactableType == InteractableType.SHOP_UNLOCKABLE)
        {
            if (other.CompareTag("Player"))
            {
                anim.enabled = false;
            }
        }
    }
}
