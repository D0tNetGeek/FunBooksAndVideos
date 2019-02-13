using System.Collections.Generic;
using FunBooksAndVideos.Helpers;
using FunBooksAndVideos.Managers.Abstracts;
using FunBooksAndVideos.ViewModels;

namespace FunBooksAndVideos.Managers
{
    public class ItemManager : IItemManager
    {

        public IEnumerable<ItemVm> GetItems()
        {
            return new List<ItemVm>
            {
                new ItemVm
                {
                    Id = 1,
                    Type =  ItemType.Video.ToString(),
                    Name = "Comprehensive First Aid Training",
                    Price = 40
                },

                new ItemVm
                {
                    Id = 2,
                    Type =  ItemType.Book.ToString(),
                    Name = "The Girl on the train",
                    Price = 10
                },

                new ItemVm
                {
                    Id = 2,
                    Type =  ItemType.Membership.ToString(),
                    Name = "Book Club",
                    Price = 100
                }
            };
        }

    }
}
