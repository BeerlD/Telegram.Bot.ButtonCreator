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
        private readonly List<List<InlineKeyboardButton>> Buttons = [[]];
        private int lineIndex = 0;

        public class ButtonData
        {
            public ButtonType? Type { get; set; }
            public string? Url { get; set; }
            public string? Id { get; set; }
        }


        public void CreateNewLine()
        {
            Buttons.Add([]);
            lineIndex += 1;
        }

        public void AddButton(string title, ButtonData? buttonData)
        {
            if (buttonData is null || buttonData.Type is null || buttonData.Type == ButtonType.Normal)
                Buttons[lineIndex].Add(InlineKeyboardButton.WithCallbackData(title, buttonData is not null ? (buttonData.Id ?? "") : ""));
            else if (buttonData.Type == ButtonType.Link)
                Buttons[lineIndex].Add(InlineKeyboardButton.WithUrl(title, buttonData.Url ?? ""));
        }

        public InlineKeyboardMarkup GetLayout()
        {
            return new InlineKeyboardMarkup(Buttons);
        }
    }
}
