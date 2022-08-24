﻿using ProjectM.Network;
using BloodyShop.DB;
using BloodyShop.Network.Messages;
using System.Text.Json;
using Wetstone.API;
using BloodyShop.Server.DB;
using System;

namespace BloodyShop.Server.Network
{
    public class ServerListMessageAction
    {

        public static void Received(User fromCharacter, ListSerializedMessage msg)
        {

            msg = createMsg();

            Send(fromCharacter,msg);

            Plugin.Logger.LogInfo($"[SERVER] [RECEIVED] ListSerializedMessage {fromCharacter.CharacterName}");

        }

        public static ListSerializedMessage createMsg()
        {

            var msg = new ListSerializedMessage();
            var productList = ItemsDB.getProductListForSaveJSON();
            var jsonOutPut = JsonSerializer.Serialize(productList);

            msg.ItemsJson = jsonOutPut;
            msg.CoinGUID = ShareDB.getCoinGUID().ToString();
            msg.ShopName = ConfigDB.getStoreName();

            if (ConfigDB.getShopEnabled())
            {
                msg.ShopOpen = "1";
            }
            else
            {
                msg.ShopOpen = "0";
            }

            return msg;
        }

        public static void Send(User fromCharacter, ListSerializedMessage msg)
        {
            VNetwork.SendToClient(fromCharacter, msg);
            Plugin.Logger.LogInfo($"[SERVER] [SEND] ListSerializedMessage {fromCharacter.CharacterName} - {msg.ItemsJson} - {msg.CoinGUID} - {msg.ShopName} - {msg.ShopOpen}");
        }

    }
}
