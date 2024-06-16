using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public GameObject e_key = null;
    bool canInteract = false;

    PlayerManager m_player = null;
    InventoryManager m_inventory = null;
    CanvasManager m_canvas = null;
    GameManager m_game = null;
    InteractableObject p_interactableObject = null;

    CollectableItem collectableItem = null;

    void Awake()
    {
        m_player = GetComponent<PlayerManager>();
        m_inventory = GetComponent<InventoryManager>();

        m_canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasManager>();
        m_game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
        else if (other.gameObject.layer == 7)
        {
            collectableItem = other.GetComponent<CollectableItem>();
            m_inventory.inventory.AddItem(collectableItem);
            m_canvas.UpdateInventory();
            m_canvas.OpenInventoryMenu();
            Destroy(other.gameObject);
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
        if (other.gameObject.CompareTag("CoinPanelTrigger"))
        {
            if (other.bounds.max.y < transform.position.y)
            {
                StartCoroutine(m_canvas.PanelShowSmoothly(m_canvas.coinsPanel, m_canvas.coinsPanelTarget, 1f, false));
            }
            else
            {
                StartCoroutine(m_canvas.PanelShowSmoothly(m_canvas.coinsPanel, m_canvas.coinsPanelStart, 1f, false));
            }
        }
    }

    void Interact()
    {
        if (canInteract)
        {
            switch (p_interactableObject.interactableType)
            {
                case InteractableObject.InteractableType.DOOR:
                    if (m_canvas.Cor_active)
                    {
                        transform.position = p_interactableObject.endPos;
                        break;
                    }
                    StartCoroutine(m_canvas.PlayBlackFade(transform, p_interactableObject.endPos, m_player));
                    break;
                case InteractableObject.InteractableType.SHOP_UNLOCKABLE:
                    print("TRIED TO BUY UNLOCKABLE");
                    if (m_game.GetCurrentCoins() < p_interactableObject.cost) { print("Not enough money"); return; }
                    m_game.UpdateCoins(-p_interactableObject.cost);
                    m_canvas.AddUnlockedOutfit();
                    m_canvas.OpenOutfitMenu();
                    p_interactableObject.unlockable.UnlockItem();
                    p_interactableObject.unlockable.PlayBump();
                    p_interactableObject.gameObject.SetActive(false);
                    break;
                case InteractableObject.InteractableType.SHOP_ITEM:
                    print("BOUGHT ITEM");
                    break;
                case InteractableObject.InteractableType.CHEST:
                    if (p_interactableObject.sr.sprite == p_interactableObject.sprites[1]) return;
                    m_game.UpdateCoins(p_interactableObject.coinsToAdd);
                    p_interactableObject.sr.sprite = p_interactableObject.sprites[1];
                    p_interactableObject.chestContent.SetActive(true);
                    StartCoroutine(m_canvas.PanelShowSmoothly(m_canvas.coinsPanel, m_canvas.coinsPanelTarget, 1f, true));
                    break;
                case InteractableObject.InteractableType.BOOKCASE:
                    print("isShop");
                    break;
                default:
                    break;
            }
        }
    }
}
