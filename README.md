# telegram.bot.buttoncreator.ButtonCreator

This package provides an easy way to create inline buttons for Telegram bots using the `telegram.bot.buttoncreator` library.

## Installation

Make sure you have the `telegram.bot.buttoncreator` library installed in your project.

```sh
Install-Package telegram.bot.buttoncreator
```

## How to Use

### Importing the Namespace

To use the `ButtonCreator` class, first import the necessary namespace:

```csharp
using Telegram.Bot.ButtonCreator;
```

### Creating an Inline Keyboard

```csharp
ButtonCreator Buttons = new();
```

### Adding Buttons

#### Normal Button (with CallbackData)
> ![Button Normal Image Example](https://raw.githubusercontent.com/BeerlD/Telegram.Bot.ButtonCreator/refs/heads/master/Assets/Images/button_normal.png)

```csharp
Buttons.AddButton("Click Here", new ButtonCreator.ButtonData { Id = "button1" });
```

#### Button with Link
> ![Button Link Image Example](https://raw.githubusercontent.com/BeerlD/Telegram.Bot.ButtonCreator/refs/heads/master/Assets/Images/button_link.png)

```csharp
Buttons.AddButton("Visit Website", new ButtonCreator.ButtonData { Type = ButtonType.Link, Url = "https://example.com" });
```

### Creating a New Line of Buttons
> ![Buttons With Line Image Example](https://raw.githubusercontent.com/BeerlD/Telegram.Bot.ButtonCreator/refs/heads/master/Assets/Images/buttons_with_line.png)

If you want to add buttons on a new line:

```csharp
Buttons.AddButton("Button 1", new ButtonCreator.ButtonData { Id = "button1" });
Buttons.AddButton("Button 2", new ButtonCreator.ButtonData { Id = "button2" });
Buttons.CreateNewLine();
Buttons.AddButton("Button 3", new ButtonCreator.ButtonData { Id = "button3" });
Buttons.AddButton("Button 4", new ButtonCreator.ButtonData { Id = "button4" });
```

### Getting the Keyboard Layout

After adding all the desired buttons, get the keyboard to be sent along with a message:

```csharp
await botClient.SendTextMessage(chatId, "Choose an option:", replyMarkup: Buttons.GetLayout());
```

### Full Example

```csharp
using Telegram.Bot.ButtonCreator;

ButtonCreator Buttons = new();

Buttons.AddButton("Button 1", new ButtonCreator.ButtonData { Id = "btn1" });
Buttons.AddButton("Button 2", new ButtonCreator.ButtonData { Id = "btn2" });
Buttons.CreateNewLine();
Buttons.AddButton("Google", new ButtonCreator.ButtonData { Type = ButtonType.Link, Url = "https://google.com" });

InlineKeyboardMarkup keyboard = buttonCreator.GetLayout();
```

This `keyboard` can be sent with a message using the Telegram Bot API:

```csharp
await botClient.SendTextMessage(chatId, "Choose an option:", replyMarkup: keyboard);
```
