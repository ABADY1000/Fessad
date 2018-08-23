using System.Collections.Generic;

namespace Fessad_TL
{
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Sengelton

        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor

        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initial = "LA",
                    Message = "Hello people, how are you, my program is very awesome.",
                    ChatIconColorRGB = "1397EF",
                    IsThereNewMessage = true
                },
                new ChatListItemViewModel
                {
                    Name = "Simon",
                    Initial = "SN",
                    Message = "I have used this program and it is so awesome.",
                    ChatIconColorRGB = "0ddd14"
                },
                new ChatListItemViewModel
                {
                    Name = "Jeff",
                    Initial = "JK",
                    Message = "This program is pretty well, I found some other similar choices, but I prefer it.",
                    ChatIconColorRGB = "dd0d1e"
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initial = "LA",
                    Message = "Hello people, how are you, my program is very awesome.",
                    ChatIconColorRGB = "1397EF"
                },
                new ChatListItemViewModel
                {
                    Name = "Simon",
                    Initial = "SN",
                    Message = "I have used this program and it is so awesome.",
                    ChatIconColorRGB = "0ddd14"
                },
                new ChatListItemViewModel
                {
                    Name = "Jeff",
                    Initial = "JK",
                    Message = "This program is pretty well, I found some other similar choices, but I prefer it.",
                    ChatIconColorRGB = "dd0d1e"
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initial = "LA",
                    Message = "Hello people, how are you, my program is very awesome.",
                    ChatIconColorRGB = "1397EF"
                },
                new ChatListItemViewModel
                {
                    Name = "Simon",
                    Initial = "SN",
                    Message = "I have used this program and it is so awesome.",
                    ChatIconColorRGB = "0ddd14"
                },
                new ChatListItemViewModel
                {
                    Name = "Jeff",
                    Initial = "JK",
                    Message = "This program is pretty well, I found some other similar choices, but I prefer it.",
                    ChatIconColorRGB = "dd0d1e"
                },
            };
        }

        #endregion

    }
}