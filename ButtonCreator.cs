using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.ButtonCreator
{
    public class ButtonCreator
    {
        private List<List<InlineKeyboardButton>> Buttons = new List<List<InlineKeyboardButton>>();
        private int lineIndex = 0;

        public void CreateNewLine()
        {
            Buttons.Add(new List<InlineKeyboardButton>());
            lineIndex += 1;
        }

        public void AddButton(string title, string id)
        {
            Buttons[lineIndex].Add(InlineKeyboardButton.WithCallbackData(title, id));
        }

        public InlineKeyboardMarkup GetLayout()
        {
            return new InlineKeyboardMarkup(Buttons);
        }
    }
}
