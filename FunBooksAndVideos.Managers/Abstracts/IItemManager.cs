using System.Collections.Generic;
using FunBooksAndVideos.ViewModels;

namespace FunBooksAndVideos.Managers.Abstracts
{
    public interface IItemManager
    {
        IEnumerable<ItemVm> GetItems();
    }
}
