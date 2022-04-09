using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Items.Interfaces;

namespace QuestGame.Items
{
    public class BaseItem : ISlotItem
    {
        public string Title { get; set; }
        public int Count { get; set; }

        public BaseItem(string title, int count)
        {
            Title = title;
            Count = count;
        }
    }
}
