using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClickItem : PointClickAction {
    public RectTransform ItemCanvasPrefab;
    RectTransform _itemCanvasObj;
    public override void OnClicked(RaycastHit hitInfo)
    {
        Debug.Log(hitInfo.collider.name + " clicked!");
        if (_itemCanvasObj == null) _itemCanvasObj = Instantiate<RectTransform>(ItemCanvasPrefab);
        _itemCanvasObj.position = hitInfo.collider.transform.position;
        _itemCanvasObj.LookAt(-Camera.main.transform.position);

    }
}
