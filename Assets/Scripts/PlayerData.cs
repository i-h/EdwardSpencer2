using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour{
    public static PlayerData Instance;
    public List<ItemData> Inventory = new List<ItemData>();
    public InventoryPanel InventoryPanelObj;
    private void Awake()
    {
        Instance = this;
    }
    public void PickUpItem(ItemData itm)
    {
        if (!Inventory.Contains(itm)) Inventory.Add(itm);
        Debug.Log("Added item to inventory: " + itm.Name);
    }
    public void ShowInventory()
    {
        if (InventoryPanelObj != null)
        {
            if (InventoryPanelObj.isActiveAndEnabled)
            {
                InventoryPanelObj.gameObject.SetActive(false);
            }
            else
            {
                InventoryPanelObj.gameObject.SetActive(true);
                InventoryPanelObj.ShowInventory(Inventory);
            }
        }
    }
}
