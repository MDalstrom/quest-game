using QuestGame.Core.Interfaces;

namespace QuestGame.Core.Players
{
    public class EmptyMessage : IPlayable
    {
        public string Content => "";
    }
}
