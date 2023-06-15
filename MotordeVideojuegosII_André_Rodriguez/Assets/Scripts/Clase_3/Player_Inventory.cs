using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        Collectable_Item.Oncollected += CollectItem;
    }

    private void OnDestroy()
    {
        Collectable_Item.Oncollected -= CollectItem;
    }

    private void CollectItem(Item item, Vector3 position)
    {
        ItemStack stack = inventory.items.Find(s => s.item == item);
        if (stack != null)
        {
            stack.quantity++;
        }
        else
        {
            inventory.items.Add(new ItemStack { item = item, quantity = 1 });
        }
    }
}
