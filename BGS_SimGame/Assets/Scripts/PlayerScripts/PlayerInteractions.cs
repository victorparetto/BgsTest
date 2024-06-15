using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public GameObject e_key = null;
    bool canInteract = false;

    PlayerManager m_player = null;
    CanvasManager m_canvas = null;
    InteractableObject p_interactableObject = null;

    void Start()
    {
        m_player = GetComponent<PlayerManager>();
        m_canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            canInteract = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            p_interactableObject = other.GetComponent<InteractableObject>();
            canInteract = true;
            if (p_interactableObject.immediateInteraction)
            {
                Interact();
                canInteract = false;
            }
            else
            {
                e_key.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if (p_interactableObject.gameObject != other.gameObject) return;
            p_interactableObject = null;
            canInteract = false;
            e_key.SetActive(false);
        }
    }

    void Interact()
    {
        if (canInteract)
        {
            switch (p_interactableObject.interactableType)
            {
                case InteractableObject.InteractableType.DOOR:
                    if (m_canvas.CR_active)
                    {
                        transform.position = p_interactableObject.endPos;
                        break;
                    }
                    StartCoroutine(m_canvas.PlayBlackFade(transform, p_interactableObject.endPos, m_player));
                    break;
                case InteractableObject.InteractableType.SHOP_ITEM:
                    print("BOUGHT ITEM");
                    break;
                case InteractableObject.InteractableType.CHEST:
                    if (p_interactableObject.sr.sprite == p_interactableObject.sprites[1]) return;
                    p_interactableObject.sr.sprite = p_interactableObject.sprites[1];
                    break;
                case InteractableObject.InteractableType.BOOKCASE:
                    print("isShop");
                    break;
                case InteractableObject.InteractableType.BED:
                    print("isShop");
                    break;
                default:
                    break;
            }
        }
    }
}
