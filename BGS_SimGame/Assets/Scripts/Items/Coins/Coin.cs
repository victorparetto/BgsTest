using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] bool goUp = false;

    bool canAnimate = true;

    Rigidbody2D rb2d = null;
    Animator animController = null;

    void Start()
    {
        animController = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
        if (goUp)
        {
            rb2d.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        PlayCoinUpAnimation();
    }

    void PlayCoinUpAnimation()
    {
        if (goUp)
        {
            if (rb2d.velocity.y == 0)
            {
                canAnimate = true;
            }
            else if (rb2d.velocity.y < 0.5f && canAnimate)
            {
                canAnimate = false;
                animController.SetTrigger("Bump");
            }

        }
    }
}
