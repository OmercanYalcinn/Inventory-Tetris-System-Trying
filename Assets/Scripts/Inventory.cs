using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<(Item, Item)> Inventory_Slots = new List<(Item, Item)>();

    // Decision directly decided that slot is not available
    private bool slotDecide = false;

    private bool isSlotAvailable() 
    {
        //if(Trigger_Control.IsItemTriggerSlot == true)
        //{
        //    if (slotDecide == true)
        //    {
        //        Inventory_Slots.Add();
        //    }
        //}

        return slotDecide;
    }


}
