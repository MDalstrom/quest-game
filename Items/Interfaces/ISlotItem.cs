using Newtonsoft.Json;

namespace QuestGame.Items.Interfaces
{
    public interface ISlotItem
    {
        string Title { get; set; }
        int Count { get; set; }
    }
}
