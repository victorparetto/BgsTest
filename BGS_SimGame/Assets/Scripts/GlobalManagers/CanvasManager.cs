using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject blackFade = null;
    Animator blackFade_anim = null;
    [HideInInspector] public bool Cor_active = false;

    int numberOfOutfitsUnlocked = 1;

    //Managers
    GameManager m_game = null;
    CanvasButtons m_buttons = null;
    InventoryManager m_inventory = null;

    //Canvas Panels
    public RectTransform coinsPanel = null;
    [HideInInspector] public Vector3 coinsPanelTarget = Vector3.zero;
    [HideInInspector] public Vector3 coinsPanelStart = Vector3.zero;

    public RectTransform outfitPanel = null;
    public GameObject outfitOpenButton_go = null;
    [HideInInspector] public Vector3 outfitPanelTarget = Vector3.zero;
    [HideInInspector] public Vector3 outfitPanelStart = Vector3.zero;

    public RectTransform inventoryPanel = null;
    [HideInInspector] public Vector3 inventoryPanelTarget = Vector3.zero;
    [HideInInspector] public Vector3 inventoryPanelStart = Vector3.zero;

    //Inventory Management
    GameObject itemSlotPrefab = null;
    GameObject slots_go = null;
    public List<ItemSlot> slots = new List<ItemSlot>();

    //Canvas Texts
    public TMP_Text coinsText = null;

    void Start()
    {
        m_game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        m_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        m_buttons = GetComponent<CanvasButtons>();

        coinsPanelStart = coinsPanel.anchoredPosition;
        coinsPanelTarget = Vector3.zero;

        outfitPanelStart = outfitPanel.anchoredPosition;
        outfitPanelTarget = Vector3.zero;

        inventoryPanelStart = inventoryPanel.anchoredPosition;
        inventoryPanelTarget = Vector3.zero;

        if (blackFade) blackFade_anim = blackFade.GetComponent<Animator>();
    }

    public void AddUnlockedOutfit()
    {
        print(numberOfOutfitsUnlocked);
        numberOfOutfitsUnlocked += 1;

        if (numberOfOutfitsUnlocked > 1)
        {
            outfitOpenButton_go.SetActive(true);
        }
    }

    public void OpenOutfitMenu()
    {
        if (outfitPanel.anchoredPosition != (Vector2)outfitPanelStart) return;
        StartCoroutine(PanelShowSmoothly(outfitPanel, outfitPanelTarget, 0.5f, false));
        m_buttons.outfitPanelIsOpen = true;
    }

    public void OpenInventoryMenu()
    {
        UpdateInventory();
        if (inventoryPanel.anchoredPosition != (Vector2)inventoryPanelStart) return;
        StartCoroutine(PanelShowSmoothly(inventoryPanel, inventoryPanelTarget, 0.5f, false));
        m_buttons.inventoryPanelIsOpen = true;
    }

    public void UpdateInventory()
    {
        if (slots.Count == m_inventory.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (m_inventory.inventory.slots[i].collectableType != CollectableType.NONE)
                {
                    slots[i].SetSlot(m_inventory.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public IEnumerator PlayBlackFade(Transform transformToMove, Vector2 endPos, PlayerManager m_player)
    {
        Cor_active = true;
        blackFade_anim.SetTrigger("fade");
        m_player.playerCanMove = false;
        yield return new WaitUntil(() => blackFade_anim.GetCurrentAnimatorStateInfo(0).IsName("Black_FadeOut_anim") == true);
        transformToMove.transform.position = endPos;
        m_player.playerCanMove = true;

        yield return new WaitUntil(() => blackFade_anim.GetCurrentAnimatorStateInfo(0).IsName("Black_Fade_idle") == true);
        Cor_active = false;
    }

    public IEnumerator PanelShowSmoothly(RectTransform rectTransToMove, Vector3 target, float duration, bool goBack)
    {
        float currentTime = 0;

        Vector3 origin = rectTransToMove.anchoredPosition;

        while (currentTime <= duration)
        {
            currentTime += Time.deltaTime;
            float percent = Mathf.Clamp01(currentTime / duration);

            float smooth = percent * percent * (3f - 2f * percent);
            rectTransToMove.anchoredPosition = Vector3.Lerp(origin, target, smooth);
            yield return null;
        }

        rectTransToMove.anchoredPosition = (Vector2)target;

        if (goBack)
        {
            yield return new WaitForSeconds(duration);
            StartCoroutine(PanelShowSmoothly(rectTransToMove, origin, duration, false));
        }
    }
}
