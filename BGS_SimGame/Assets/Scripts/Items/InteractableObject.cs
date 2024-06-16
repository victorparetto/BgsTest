using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public bool immediateInteraction = false;

    public enum InteractableType
    {
        NONE,
        DOOR,
        SHOP_UNLOCKABLE,
        SELLER,
        CHEST,
    }
    public InteractableType interactableType;

    [Header("Variables for Door")]
    //Door enum variables
    public Vector2 endPos;

    [Header("Variables for Unlockable")]
    //Shop_Unlockable enum variables
    public Animator anim;
    public Unlockable unlockable;
    public int cost = 100;
    public TMP_Text textToModify = null;

    [Header("Variables for Chests")]
    //Chest enum variables
    public int coinsToAdd = 0;
    public SpriteRenderer sr;
    public Sprite[] sprites; //0 = closed, 1 = open
    public GameObject chestContent = null;

    void Start()
    {
        if (interactableType == InteractableType.SHOP_UNLOCKABLE)
        {
            textToModify.text = cost.ToString();
        }
    }

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
