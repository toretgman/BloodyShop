﻿using BloodyShop.Client.DB;
using BloodyShop.Client.Network;
using BloodyShop.Client.Patch;
using BloodyShop.Client.UI;
using System;
using UnityEngine;

namespace BloodyShop.Client
{
    public class KeyBindPressed
    {
        internal static void OnKeyPressedOpenPanel(KeyBindFunction keybindFunction)
        {
            switch (keybindFunction)
            {
                case KeyBindFunction.ToggleShopUI:
                    if (ClientMod.UIInit)
                    {
                        if (UIManager.ActiveShopPanel || UIManager.ActiveDeleteItemPanel || UIManager.ActiveAddItemPanel)
                        {
                            UIManager.ActiveShopPanel = false;
                            try
                            {
                                UIManager.ShopPanel?.Destroy();
                            } catch { }
                            
                            if (ClientDB.userModel.IsAdmin)
                            {
                                UIManager.ActiveDeleteItemPanel = false;
                                UIManager.DeleteItemPanel?.Destroy();
                            }
                            if (ClientDB.userModel.IsAdmin)
                            {
                                UIManager.ActiveAddItemPanel = false;
                                UIManager.AddItemPanel?.Destroy();
                            }
                        }
                        else
                        {
                            if (UIManager.ActiveShopPanel == false)
                            {
                                UIManager.OpenShopPanel();
                            }
                            if (UIManager.ActiveDeleteItemPanel == false)
                            {
                                if (ClientDB.userModel.IsAdmin)
                                {
                                    UIManager.OpenDeletePanel();
                                }
                            }
                            if (UIManager.ActiveAddItemPanel == false)
                            {
                                if (ClientDB.userModel.IsAdmin)
                                {
                                    UIManager.OpenAddItemPanel();
                                }
                            }
                        }
                        
                       
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(keybindFunction), keybindFunction, null);
            }
        }
    }
}
