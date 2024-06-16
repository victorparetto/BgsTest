using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButtons : MonoBehaviour
{
    CanvasManager m_canvas = null;
    OutfitManager m_outfit = null;

    [HideInInspector] public bool outfitPanelIsOpen = false;

    void Start()
    {
        m_canvas = gameObject.GetComponent<CanvasManager>();
        m_outfit = GameObject.FindGameObjectWithTag("Player").GetComponent<OutfitManager>();
    }

    void Update()
    {
        print(outfitPanelIsOpen);
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

    public void ChangeOutfit(int id)
    {
        m_outfit.ChangeOutfit(id);
    }
}
