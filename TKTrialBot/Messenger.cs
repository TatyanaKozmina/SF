﻿namespace TKTrialBot
{
    class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            var delimiter = ",";
            var text = "Your history: " + string.Join(delimiter, chat.GetTextMessages().ToArray());

            return text;
        }
    }
}
