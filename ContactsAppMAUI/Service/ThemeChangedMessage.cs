using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ContactsAppMAUI.Service
{
	public class ThemeChangedMessage : ValueChangedMessage<string>
	{
		public ThemeChangedMessage(string value) : base(value)
		{
		}
	}
}