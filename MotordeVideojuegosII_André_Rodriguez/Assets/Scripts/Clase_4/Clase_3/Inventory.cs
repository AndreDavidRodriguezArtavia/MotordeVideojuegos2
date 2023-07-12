using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemStackKeyObject> itemsKeyObject = new List<ItemStackKeyObject>();
    public List<ItemStackFood> itemsFoods = new List<ItemStackFood>();
    public List<ItemStackGun> itemsGuns = new List<ItemStackGun>();
}

[Serializable]
public class ItemStackKeyObject
{
    public Item KeyObject;
    public int quantityKeyObject;
    
}
public class ItemStackFood
{
    public Item Food;
    public int quantityFood;
}

public class ItemStackGun
{
    public Item Gun;
    public int quantityGun;
}
