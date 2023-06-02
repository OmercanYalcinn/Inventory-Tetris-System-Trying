using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Control : MonoBehaviour
{
    public GameObject gameObject;

    [SerializeField] private bool isItemTriggerSlot = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slot")
        {
            isItemTriggerSlot = true;
            Debug.Log("OnTrigger");
        }
    }

    public bool IsItemTriggerSlot 
    {
        get { return isItemTriggerSlot; }
        set { isItemTriggerSlot = value; }
    }
}
