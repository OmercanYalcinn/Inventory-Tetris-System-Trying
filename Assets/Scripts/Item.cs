using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // itemType Object is created
    [SerializeField] private ItemType itemType;

    private void Start()
    {
        transform.localScale = itemType.Item_Scale;
    }

}
