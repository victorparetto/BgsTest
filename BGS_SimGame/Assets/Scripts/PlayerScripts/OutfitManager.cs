using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    public RuntimeAnimatorController originalController = null;
    public List<AnimatorOverrideController> outfits = new List<AnimatorOverrideController>();

    public int currentOutfitID = 0;

    public void ChangeOutfit(int id)
    {
        if (id > 0)
        {
            anim.runtimeAnimatorController = outfits[id];
        }
        else
        {
            anim.runtimeAnimatorController = originalController;
        }
    }
}
