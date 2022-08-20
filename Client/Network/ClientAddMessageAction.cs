﻿using BloodyShop.Network.Messages;
using Wetstone.API;

namespace BloodyShop.Client.Network
{
    public class ClientAddMessageAction
    {

        public static void Received(AddSerializedMessage msg)
        {
            Plugin.Logger.LogInfo($"[CLIENT] [RECEIVED] CloseSerializedMessage");
        }

        public static void Send(AddSerializedMessage msg = null)
        {

            if (msg == null)
            {
                msg = new AddSerializedMessage();
                msg.PrefabGUID = "0";
                msg.Price = "0";
                msg.Quantity = "0";
            }

            VNetwork.SendToServer(msg);
            Plugin.Logger.LogInfo($"[CLIENT] [SEND] CloseSerializedMessage");
        }

    }
}