using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRow : MonoBehaviour {
    public ItemData DisplayedItem;
    Image Icon;
    Text NameLabel;

    private void Awake()
    {
        Icon = GetComponentInChildren<Image>();
        NameLabel = GetComponentInChildren<Text>();
    }

    public void SetItemData(ItemData itm)
    {
        DisplayedItem = itm;
        if(Icon != null) Icon.sprite = itm.Icon;
        if(NameLabel != null) NameLabel.text = itm.Name;
    }
}
