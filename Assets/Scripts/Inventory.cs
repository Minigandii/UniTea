using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public int coinsCount;
   public Text coinsCountText;

   public List<Item> content = new List<Item>();
   public int contentCurrentIndex = 0;
   public Image itemImageUI;
   public Text itemNameUI;
   public Sprite emptyItemImage;

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

   private void Start()
   {
    UpdateIventoryUI();
   }

   public void ConsumeItem()
   {
        if(content.Count == 0)
        {
            return;
        }

        Item currentItem = content[0];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        PlayerMovement.instance.moveSpeed += currentItem.speedGiven;
        content.Remove(currentItem);
        GetNextItem();
        UpdateIventoryUI();
   }

   public void GetNextItem()
   {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateIventoryUI();
   }

   public void GetPreviousItem()
   {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateIventoryUI();
   }

   public void UpdateIventoryUI()
   {
        if(content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
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
