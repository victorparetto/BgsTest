using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlockable : MonoBehaviour
{
    public int id = 0;

    public bool isUnlocked = false;
    public bool resetColor = false;

    Animator anim;
    Button buttonComp;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (gameObject.GetComponent<Button>()) buttonComp = GetComponent<Button>();

        if (isUnlocked)
        {
            UnlockItem();
        }
    }

    public void UnlockItem()
    {
        isUnlocked = true;
        if (buttonComp) buttonComp.enabled = true;

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
