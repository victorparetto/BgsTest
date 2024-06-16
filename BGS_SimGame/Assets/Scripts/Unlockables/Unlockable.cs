using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlockable : MonoBehaviour
{
    public bool isUnlocked = false;
    public bool resetColor = false;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        if (isUnlocked)
        {
            UnlockItem();
        }
    }

    public void UnlockItem()
    {
        isUnlocked = true;

        if (resetColor)
        {
            print(gameObject.GetComponent<Image>());
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void PlayBump()
    {
        anim.SetTrigger("Bump");
    }
}
