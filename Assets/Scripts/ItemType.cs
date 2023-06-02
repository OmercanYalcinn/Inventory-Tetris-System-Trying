using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New_Item_Type", menuName = "Item_Type")]

public class ItemType : ScriptableObject
{
    [SerializeField] private string itemName;

    // Tile size(Inventory Slot) decision variables - Item object is 1*1 default
    [SerializeField] private Vector2 item_scale = Vector2.one;
    
    [SerializeField] private int coverCost;

    // What will be occure in inventorySlot
    [SerializeField] private Sprite visiual;

    // The description of the item, why we need them and what they do explaination
    [SerializeField] private string description;

    public Vector2 Item_Scale
    {
        get { return item_scale; }
        set { item_scale = value; }
    }


}
