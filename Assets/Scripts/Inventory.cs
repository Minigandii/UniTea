using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public int coinsCount;
   public Text coinsCountText;

   public List<Item> content = new List<Item>();
   public int contentCurrentIndex = 0;

   public static Inventory instance;

   private void Awake()
   {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        
        instance = this;
   }

   public void ConsumeItem()
   {
        Item currentItem = content[0];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        PlayerMovement.instance.moveSpeed += currentItem.speedGiven;
        content.Remove(currentItem);
        GetNextItem();
   }

   public void GetNextItem()
   {
    contentCurrentIndex++;
    if(contentCurrentIndex > content.Count - 1)
    {
        contentCurrentIndex = 0;
    }
   }

   public void GetPreviousItem()
   {
    contentCurrentIndex--;
    if(contentCurrentIndex < 0)
    {
        contentCurrentIndex = content.Count - 1;
    }
   }

   public void AddCoins(int count)
   {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
   }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}
