﻿/*using BloodyShop.Client.DB;
using BloodyShop.Client.UI;
using BloodyShop.DB;
using BloodyShop.DB.Models;
using BloodyShop.Network.Messages;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Bloody.Core.GameData.v1;
using Bloodstone.API;

namespace BloodyShop.Client.Network
{
    public class ClientListMessageAction
    {

        public static void Received(ListSerializedMessage msg)
        {
           // Plugin.Logger.LogInfo($"[CLIENT] [RECEIVED] ListSerializedMessage {msg.ItemsJson}");

            var productList = JsonSerializer.Deserialize<List<ItemShopModel>>(msg.ItemsJson);
            var currencyList = JsonSerializer.Deserialize<List<CurrencyModel>>(msg.CurrencyJson);

            ShareDB.setCurrencyList(currencyList);
            ItemsDB.setProductList(productList);
            

            if (ClientDB.IsAdmin)
            {
                var panel = UIManager.panelCOnfig.GetActivePanel();
                panel.RefreshData();
                panel.CreateListProductsLayout();
                var panelCurrency = UIManager.panelCOnfig.GetCurrencyPanel();
                panelCurrency.RefreshData();
                panelCurrency.CreateListCurrenciesLayout();
            }

            UIManager.ShopPanel.RefreshData();
            UIManager.ShopPanel.CreateListProductsLayout();
            
        }

        public static void Send(ListSerializedMessage msg = null)
        {
            //Plugin.Logger.LogInfo($"[CLIENT] [SEND] ListSerializedMessage");
            if (msg == null)
            {
                msg = new ListSerializedMessage();
                msg.ItemsJson = "list";
            }

            VNetwork.SendToServer(msg);
            
        }

    }
}
*/