using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButtons : MonoBehaviour
{
    CanvasManager m_canvas = null;
    OutfitManager m_outfit = null;

    [HideInInspector] public bool outfitPanelIsOpen = false;
    [HideInInspector] public bool inventoryPanelIsOpen = false;

    void Start()
    {
        m_canvas = gameObject.GetComponent<CanvasManager>();
        m_outfit = GameObject.FindGameObjectWithTag("Player").GetComponent<OutfitManager>();
    }

    public void MoveOutfitMenu()
    {
        if (outfitPanelIsOpen)
        {
            if (m_canvas.outfitPanel.anchoredPosition.x >= m_canvas.outfitPanelTarget.x + 0.5) return;
            StartCoroutine(m_canvas.PanelShowSmoothly(m_canvas.outfitPanel, m_canvas.outfitPanelStart, 0.5f, false));
            outfitPanelIsOpen = false;

        }
        else
        {
            if (m_canvas.outfitPanel.anchoredPosition.x <= m_canvas.outfitPanelStart.x - 0.5) return;
            StartCoroutine(m_canvas.PanelShowSmoothly(m_canvas.outfitPanel, m_canvas.outfitPanelTarget, 0.5f, false));
            outfitPanelIsOpen = true;
        }
    }

    public void MoveInventoryMenu()
    {
        if (inventoryPanelIsOpen)
        {
            if (m_canvas.inventoryPanel.anchoredPosition.x >= m_canvas.inventoryPanelTarget.x + 0.5) return;
            StartCoroutine(m_canvas.PanelShowSmoothly(m_canvas.inventoryPanel, m_canvas.inventoryPanelStart, 0.5f, false));
            inventoryPanelIsOpen = false;

        }
        else
        {
            if (m_canvas.inventoryPanel.anchoredPosition.x <= m_canvas.inventoryPanelStart.x - 0.5) return;
            StartCoroutine(m_canvas.PanelShowSmoothly(m_canvas.inventoryPanel, m_canvas.inventoryPanelTarget, 0.5f, false));
            inventoryPanelIsOpen = true;
        }
    }

    public void ChangeOutfit(int id)
    {
        m_outfit.ChangeOutfit(id);
    }
}
