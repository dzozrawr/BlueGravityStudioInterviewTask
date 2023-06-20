using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ClothingItems
{
    public enum ItemID
    {
        WizardHat
    }
    [CreateAssetMenu(fileName = "New Clothing Item", menuName = "Clothes/Item")]
    public class ClothingItemInfo : ScriptableObject
    {
        public ItemID id;
        public GameObject itemPrefab;
        public Sprite sprite;
        public string description;
        public int price;
    }
}
