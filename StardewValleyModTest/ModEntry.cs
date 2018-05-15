﻿using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;

namespace WarpToFriends
{
	/// <summary>The mod entry point.</summary>
	public class ModEntry : Mod
	{

		private IModHelper _helper;

		public override void Entry(IModHelper helper)
		{
			_helper = helper;
			
			InputEvents.ButtonPressed += this.InputEvents_ButtonPressed;
		}

		private void InputEvents_ButtonPressed(object sender, EventArgsInput e)
		{
			if (Context.IsWorldReady && e.Button == SButton.J)
			{
				if (!Context.IsPlayerFree)
				{
					if(Game1.activeClickableMenu is WarpMenu)
					{
						Game1.activeClickableMenu.exitThisMenu(true);
					}
				}
				else
				{
					Game1.activeClickableMenu = new WarpMenu(this.Monitor, _helper);
				}
				
			}
		}
	}
}