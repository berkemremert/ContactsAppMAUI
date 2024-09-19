using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ContactsAppMAUI.Service
{
	public class ThemeAddedMessage : ValueChangedMessage<string>
	{
		public ThemeAddedMessage(string value) : base(value)
		{
		}
	}
}