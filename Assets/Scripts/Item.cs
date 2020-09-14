using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int ID;
    public Sprite icon;

    public enum ItemType
    {
        None,
        Weapon,
        Consumable
    }

    public ItemType itemType;

    void Action()
    {
        switch (itemType)
        {
            case ItemType.Weapon:
                Debug.Log($"This item is a: {itemType}");
                break;
            case ItemType.Consumable:
                Debug.Log($"This item is a: {itemType}");
                break;
        }
    }

    void Start()
    {
        Action();
    }
}
