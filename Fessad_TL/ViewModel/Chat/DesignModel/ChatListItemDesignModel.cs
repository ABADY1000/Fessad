
using System.Collections.Specialized;

namespace Fessad_TL
{
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Sengeltone

        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

        #region Constructor

        public ChatListItemDesignModel()
        {
            Name = "Luke";
            Initial = "LA";
            Message = "Hello people, how are you, my program is very awesome";
            ChatIconColorRGB = "1397EF";
        }

        #endregion

    }
}
