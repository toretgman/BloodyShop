﻿using ProjectM;
using UnityEngine;
using Bloody.Core.Models.v1;

namespace BloodyShop.DB.Models
{
    public class PrefabModel
    {
        public string PrefabName { get; set; }
        public int PrefabPrice { get; set; }
        public int PrefabStock { get; set; }
        public int PrefabStack { get; set; }
        public string PrefabType { get; set; }
        public int PrefabGUID { get; set; }
        public Sprite PrefabIcon { get; set; }
        public ItemModel itemModel { get; set; }
        public int currency { get; set; }
        public bool isBuff { get; set; }


        /*public PrefabGUID getPrefabGUID()
        {
            return new PrefabGUID(PrefabGUID);
        }*/

        public bool CheckStockAvailability(int numberofItemsBuy)
        {
            if (PrefabStock < 0) return true;

            if (PrefabStock >= numberofItemsBuy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
