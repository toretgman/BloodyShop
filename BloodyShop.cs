﻿using HarmonyLib;
using BloodyShop.Client;
using BloodyShop.Client.Patch;
using BloodyShop.Server;
using BloodyShop.Server.Hooks;
using BloodyShop.Server.Network;
using System;

namespace BloodyShop
{
    public class BloodyShop
    {
        public static void serverInitMod(Harmony _harmony)
        {
            _harmony.PatchAll(typeof(ChatMessageSystem_Patch));
            ServerMod.CreateFilesConfig();
            ServerMod.LoadConfigToDB();
        }

        public static void clientInitMod(Harmony _harmony)
        {
            KeyBinds.Initialize();
            KeyBinds.OnKeyPressed += KeyBindPressed.OnKeyPressedOpenPanel;
        }

        public static void onServerGameInitialized(bool ShopEnabled, int CoinGUID, string StoreName)
        {
            ServerMod.SetConfigMod(ShopEnabled, CoinGUID, StoreName);
        }

        public static void onClientGameInitialized()
        {
            
        }

        public static void serverUnloadMod()
        {
            
        }

        public static void clientUnloadMod()
        {

        }

    }
}
