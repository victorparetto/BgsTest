using System.Collections;
using System.Collections.Generic;
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
                    print("isDoor");
                    break;
                case InteractableObject.InteractableType.SHOP:
                    print("isShop");
                    break;
                case InteractableObject.InteractableType.CHEST:
                    print("isShop");
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
