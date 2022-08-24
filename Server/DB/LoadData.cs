﻿using BloodyShop.DB;
using BloodyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace BloodyShop.Server.DB
{
    internal class LoadDataFromFiles
    {

        public static bool loadProductList()
        {
            try
            {
                string json = File.ReadAllText(ServerMod.ProductListFile);
                var productList = JsonSerializer.Deserialize<List<ItemShopModel>>(json);
                Plugin.Logger.LogInfo($"Total product List FROM JSON {productList.Count}");
                return ItemsDB.setProductList(productList);
            }
            catch (Exception error)
            {
                Plugin.Logger.LogError($"Error: {error.Message}");
                return false;
            }

        }
    }
}
