using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteRelativeToPlayer : MonoBehaviour
{
    [Range(0.5f, 1.5f)]
    public float distanceThreshold = 1f;

    public Sprite[] sprites; //0 = default, 1 = left, 2= right

    Transform player = null;
    SpriteRenderer spriteComp = null;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        spriteComp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (player.position.x >= transform.position.x + distanceThreshold)
        {
            spriteComp.sprite = sprites[2];
        }
        else if (player.position.x <= transform.position.x - distanceThreshold)
        {
            spriteComp.sprite = sprites[1];
        }
        else
        {
            spriteComp.sprite = sprites[0];
        }
    }
}
