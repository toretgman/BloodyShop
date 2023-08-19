﻿using ProjectM.Network;
using BloodyShop.DB;
using BloodyShop.Network.Messages;
using Bloodstone.API;
using BloodyShop.Server.Systems;
using System;
using BloodyShop.DB.Models;
using BloodyShop.Utils;
using BloodyShop.Server.DB;
using ProjectM;

namespace BloodyShop.Server.Network
{
    public class ServerDeleteCurrencyMessageAction
    {

        public static void Received(FromCharacter fromCharacter, DeleteCurrencySerializedMessage msg)
        {
            var user = VWorld.Server.EntityManager.GetComponentData<User>(fromCharacter.User);

            //Plugin.Logger.LogInfo($"[SERVER] [RECEIVED] DeleteSerializedMessage {user.CharacterName} - {msg.Item}");

            if (!user.IsAdmin)
                ServerChatUtils.SendSystemMessageToClient(VWorld.Server.EntityManager, user, FontColorChat.Red("You do not have permissions for this action"));

            var currencyID = Int32.Parse(msg.Currency);

            removeCurrencyFromShop(user, currencyID);

        }

        private static void removeCurrencyFromShop(User user, int index)
        {
            try
            {
                if (!ShareDB.SearchCurrencyByCommand(index, out CurrencyModel currencyModel))
                {
                    ServerChatUtils.SendSystemMessageToClient(VWorld.Server.EntityManager, user, FontColorChat.Red(FontColorChat.Yellow($"Currency removed error.")));
                    return;
                }
                if (!ShareDB.RemoveCurrencyyByCommand(index))
                {
                    ServerChatUtils.SendSystemMessageToClient(VWorld.Server.EntityManager, user, FontColorChat.Red($"Currency {FontColorChat.White($"{currencyModel.name}")} removed error."));
                    return;
                }

                SaveDataToFiles.saveCurrenciesList();
                LoadDataFromFiles.loadCurrencies();

                ServerChatUtils.SendSystemMessageToClient(VWorld.Server.EntityManager, user, FontColorChat.Yellow($"Currency {FontColorChat.White($"{currencyModel.name}")} removed successful."));

                var userWithUI = UserUI.GetUsersWithUI();
                foreach (var userUI in userWithUI)
                {
                    var userValue = userUI.Value;
                    if (userValue.IsConnected && userValue.IsAdmin)
                    {
                        var msg = ServerListCurrencyMessageAction.createMsg();
                        ServerListCurrencyMessageAction.Send(userValue, msg);
                    }
                }
            }
            catch (Exception error)
            {
                Plugin.Logger.LogError($"Error: {error.Message}");
                ServerChatUtils.SendSystemMessageToClient(VWorld.Server.EntityManager, user, FontColorChat.Red($"Error: {error.Message}"));
            }
        }

        public static void Send(User fromCharacter, DeleteSerializedMessage msg)
        {
           return;
        }

    }
}
