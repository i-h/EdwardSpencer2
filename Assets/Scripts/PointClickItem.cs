using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClickItem : PointClickAction {
    public RectTransform ItemInfoPanelObj;
    ItemInfoPanel _itemCanvasObj;
    public override void OnClicked(RaycastHit hitInfo)
    {
        Debug.Log(hitInfo.collider.name + " clicked!");
        if (ItemInfoPanelObj == null)
            return;
        ItemInfoPanelObj.gameObject.SetActive(true);
        if (_itemCanvasObj == null)
            _itemCanvasObj = ItemInfoPanelObj.GetComponent<ItemInfoPanel>();
        

    }
}
