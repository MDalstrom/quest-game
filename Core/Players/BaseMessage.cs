using QuestGame.Core.Interfaces;

namespace QuestGame.Core.Players
{
    public class BaseMessage : IPlayable
    {
        private string text;
        public string Content => text;

        public BaseMessage(string text)
        { 
            this.text = text;
        }
    }
}
