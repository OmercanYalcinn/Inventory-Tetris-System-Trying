using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class xInventory : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _inventoryParentObject;
    
    [SerializeField] private GameObject _gridObject;

    [SerializeField] private int _sizeX = 6;
    [SerializeField] private int _sizeY = 5;

    
    private xGrid[,] _inventoryArray;


    //TODO: EXAMPLE CODE. REMOVE LATER

    public xItem TestGameObject1;
    public int Object1IndexX = 0;
    public int Object1IndexY = 0;
    
    public xItem TestGameObject2;
    public int Object2IndexX = 1;
    public int Object2IndexY = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlaceItem(TestGameObject1,(Object1IndexX, Object1IndexY));
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlaceItem(TestGameObject2,(Object2IndexX, Object2IndexY));
        }
    }
    
    ////////////////
 private void Start()
    {
        CreateInventory(_sizeX, _sizeY);
    }

    public void CreateInventory(int sizeX, int sizeY)
    {
        _inventoryArray = new xGrid[sizeX, sizeY];
        
        for (int i = 0; i < sizeX; i++)
        for (int j = 0; j < sizeY; j++)
        {
            var currentGrid = GameObject.Instantiate(_gridObject, _inventoryParentObject.gameObject.transform.position,
                Quaternion.identity);
            _inventoryArray[i, j] = currentGrid.GetComponent<xGrid>();
            // ? Aşağı tarafı tam anlamadım - bu parent olayını çözemedim
            currentGrid.transform.SetParent(_inventoryParentObject.gameObject.transform);
        }
        
    }
    
    /*
    public void ExpandInventory(int sizeX, int sizeY)
    {
        // Conditions:
            // if there is no space in inventory,
                    // we could hit one button and expand on constant column and all rows on Matrix array - resize it what I mean.
            // else if there is enough level to upgrade our inventory
            
            // copy values from the original array to the resized array
            for (int i = 0; i < _inventoryArray.GetLength(0); i++)
            {
                for (int j = 0; j < _inventoryArray.GetLength(1); j++)
                {
                    _inventoryArray[i, j] = new xGrid();
                }
            }
    }*/

    public void AddRow()
    {
        
    }

    public void PlaceItem(xItem myItem, (int,int) placementGridIndex)
    {
        if (CheckItemPlacement(myItem, placementGridIndex) == false)
        {
            return;
        }
        
        myItem.gameObject.transform.position =
            _inventoryArray[placementGridIndex.Item1, placementGridIndex.Item2].gameObject.transform.position;
        myItem.InventoryStartIndex = placementGridIndex;

    }

    private bool CheckItemPlacement(xItem myItem, (int,int) PlacementGridIndex)
    {
        (int,int) inventoryStartIndex = (0,0);
        bool isObjectFound = false;

        for (int xDimension = 0; xDimension < _inventoryArray.GetLength(0); xDimension++)
        for (int yDimension = 0; yDimension < _inventoryArray.GetLength(1); yDimension++)
        {
            xGrid currentGrid = _inventoryArray[xDimension, yDimension];
            if (currentGrid.GridIndex == PlacementGridIndex)
            {
                inventoryStartIndex = (xDimension, yDimension);
                isObjectFound = true;
                break;
            }
        }

        if (!isObjectFound)
            return false;
        
        // Object found, check if slot's available.
        // In other words, cost check ?
        
        for (var index0 = inventoryStartIndex.Item1; index0 < myItem.CostX; index0++)
        for (var index1 = inventoryStartIndex.Item2; index1 < myItem.CostY; index1++)
        {
            try
            {
                if (_inventoryArray[index0, index1] != null)
                {
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
            var currentGrid = _inventoryArray[index0, index1];
            if (currentGrid.IsEmpty == false)
            {
                return false;
            }
        }
        return true;
    }
    
        // Ve bunu nasıl Expandable yapacağız?
}
