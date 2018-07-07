using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public ItemData Data;
}
[System.Serializable]
public class ItemData
{
    public Transform Model;
    public Sprite Icon;
    public string Name = "Unknown item";
    public string Description = "A strange mysterious item, can't really figure it out";
    public int ID = -1;
}
