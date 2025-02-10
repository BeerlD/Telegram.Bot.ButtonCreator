using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.ButtonCreator
{
    public enum ButtonType
    {
        Normal,
        Link
    }

    public class ButtonCreator
    {
        private List<List<InlineKeyboardButton>> Buttons = new List<List<InlineKeyboardButton>>() { new List<InlineKeyboardButton>() };
        private int lineIndex = 0;

        public class ButtonData
        {
            public ButtonType? Type { get; set; }
            public string? Url { get; set; }
            public string? Id { get; set; }
        }


        public void CreateNewLine()
        {
            Buttons.Add(new List<InlineKeyboardButton>());
            lineIndex += 1;
        }

        public void AddButton(string title, ButtonData? buttonData)
        {
            if (buttonData is null || buttonData.Type == ButtonType.Normal)
                Buttons[lineIndex].Add(InlineKeyboardButton.WithCallbackData(title, buttonData.Id));

            if (buttonData.Type == ButtonType.Link)
                Buttons[lineIndex].Add(InlineKeyboardButton.WithUrl(title, buttonData.Url));
        }

        public InlineKeyboardMarkup GetLayout()
        {
            return new InlineKeyboardMarkup(Buttons);
        }
    }
}
