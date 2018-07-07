using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {
    public RectTransform ContentPanel;
    public InventoryRow RowPrefab;

    public void ShowInventory(List<ItemData> inv)
    {
        Transform[] oldRows = ContentPanel.GetComponentsInChildren<Transform>(true);
        foreach (Transform gobj in oldRows)
            if (gobj != ContentPanel) Destroy(gobj.gameObject);
        
        foreach(ItemData i in inv)
        {
            InventoryRow invRow = Instantiate<InventoryRow>(RowPrefab);
            invRow.transform.SetParent(ContentPanel.transform);
            invRow.SetItemData(i);
        }
    }
}
