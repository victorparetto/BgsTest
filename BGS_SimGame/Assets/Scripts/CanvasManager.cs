using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject blackFade = null;
    Animator blackFade_anim = null;
    [HideInInspector] public bool CR_active = false;
    void Start()
    {
        if (blackFade) blackFade_anim = blackFade.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator PlayBlackFade(Transform transformToMove, Vector2 endPos, PlayerManager m_player)
    {
        CR_active = true;
        blackFade_anim.SetTrigger("fade");
        m_player.playerCanMove = false;
        yield return new WaitUntil(() => blackFade_anim.GetCurrentAnimatorStateInfo(0).IsName("Black_FadeOut_anim") == true);
        transformToMove.transform.position = endPos;
        m_player.playerCanMove = true;

        yield return new WaitUntil(() => blackFade_anim.GetCurrentAnimatorStateInfo(0).IsName("Black_Fade_idle") == true);
        CR_active = false;
    }
}
