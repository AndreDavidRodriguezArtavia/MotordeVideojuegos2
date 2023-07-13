using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        Collectable_Item.Oncollected += CollectItemkey;
        Collectable_Item.Oncollected += CollectItemFood;
        Collectable_Item.Oncollected += CollectItemGun;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            UseFood();
        }
    }

    private void OnDestroy()
    {
        Collectable_Item.Oncollected -= CollectItemkey;
        Collectable_Item.Oncollected -= CollectItemFood;
        Collectable_Item.Oncollected -= CollectItemGun;
        
    }



    private void CollectItemkey(Item item, Vector3 position)
    {
        
        ItemStackKeyObject stackKeyObjects = inventory.itemsKeyObject.Find(s => s.KeyObject == item);
       
        if (stackKeyObjects != null)
        {
            stackKeyObjects.quantityKeyObject++;

        }
        else
        {
            inventory.itemsKeyObject.Add(new ItemStackKeyObject { KeyObject = item, quantityKeyObject = 1 });
        }       
    }

    private void CollectItemFood(Item item, Vector3 position)
    {
        ItemStackFood stackFood = inventory.itemsFoods.Find(s => s.Food == item);

        if (stackFood != null)
        {
            stackFood.quantityFood++;
        }
        else
        {
            inventory.itemsFoods.Add(new ItemStackFood { Food = item, quantityFood = 1 });

            if(Input.GetKeyDown(KeyCode.Q))
            {
                inventory.itemsFoods.Add(new ItemStackFood { Food = item, quantityFood = -1 });
            }
        }


    }
    private void CollectItemGun(Item item, Vector3 position)
    {
        ItemStackGun stackGun = inventory.itemsGuns.Find(s => s.Gun == item);

        if (stackGun != null)
        {
            stackGun.quantityGun++;
        }
        else
        {
            inventory.itemsGuns.Add(new ItemStackGun { Gun = item, quantityGun = 1 });
        }
    }

    private void UseFood()
    {
        if (inventory.itemsFoods.Count > 0)
        {
            ItemStackFood foodStack = inventory.itemsFoods[0];

            foodStack.quantityFood--;

            if (foodStack.quantityFood <= 0)
            {
                inventory.itemsFoods.RemoveAt(0);
            }
        }
    }
}
