
namespace Fessad_TL
{
    public class ChatListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Initial { get; set; }

        public string Message { get; set; }

        public string ChatIconColorRGB { get; set; }

        public bool IsThereNewMessage { get; set; } = false;
    }
}
