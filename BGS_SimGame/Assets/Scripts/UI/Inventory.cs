using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType collectableType;
        public int stack;
        public int maxStack;

        public Sprite icon;

        public Slot()
        {
            collectableType = CollectableType.NONE;
            stack = 0;
            maxStack = 30;
        }

        public bool CanAddItem()
        {
            if (stack < maxStack)
            {
                return true;
            }
            else return false;
        }

        public void AddItem(CollectableItem item)
        {
            this.collectableType = item.collectableType;
            this.icon = item.icon;
            stack++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numberOfSlots)
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            Slot tempSlot = new Slot();
            slots.Add(tempSlot);
        }
    }

    public void AddItem(CollectableItem item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.collectableType == item.collectableType && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.collectableType == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}
