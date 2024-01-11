using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    public Item item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;

        if (item.price < 0)
        {
            // Selling
            if (inventory.coinsCount >= item.price)
            {
                inventory.content.Add(item);
                inventory.UpdateInventoryUI();
                inventory.coinsCount += item.price;
                inventory.UpdateTextUI();
            }
            else
            {
                Debug.LogWarning("Not enough money to buy " + item.name);
            }
        }
        else
        {
            // Buying
            if (inventory.content.Contains(item))
            {
                inventory.content.Remove(item);
                inventory.UpdateInventoryUI();
                inventory.coinsCount += Mathf.Abs(item.price); 
                inventory.UpdateTextUI();
            }
            else
            {
                Debug.LogWarning("No " + item.name + " in the inventory");
            }
        }
    }
}

