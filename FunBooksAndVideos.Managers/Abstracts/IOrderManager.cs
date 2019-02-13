using System.Collections.Generic;
using FunBooksAndVideos.ViewModels;

namespace FunBooksAndVideos.Managers.Abstracts
{
    public interface IOrderManager
    {
        CreateOrderResponse Create(List<int> itemIds);
    }
}
