using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanel : MonoBehaviour {
    public CloseButton CloseBtn;
    public PickUpButton PickUpBtn;
    public Item DisplayedItem;
    private void Awake()
    {
        CloseBtn = GetComponentInChildren<CloseButton>();
        PickUpBtn = GetComponentInChildren<PickUpButton>();
    }
    private void Start()
    {
        PickUpBtn.Btn.onClick.AddListener(PickUpDisplayedItem);
    }
    public void PickUpDisplayedItem()
    {
        PickUpItem(DisplayedItem);
    }
    public void PickUpItem(Item itm)
    {
        PlayerData.Instance.PickUpItem(itm.Data);
        Destroy(itm.gameObject);
        CloseBtn.CloseWindow();

    }
}
