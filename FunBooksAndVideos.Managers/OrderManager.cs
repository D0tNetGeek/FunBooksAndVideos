using System;
using System.Collections.Generic;
using System.Linq;
using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Helpers;
using FunBooksAndVideos.Managers.Abstracts;
using FunBooksAndVideos.ViewModels;

namespace FunBooksAndVideos.Managers
{
    public class OrderManager : IOrderManager
    {
        public CreateOrderResponse Create(List<int> itemIds)
        {
            //get items from database with maching ids
            //for testing using hard coded
            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Type =  ItemType.Video,
                    Name = "Comprehensive First Aid Training",
                    Price = 40
                },

                new Item
                {
                    Id = 2,
                    Type =  ItemType.Book,
                    Name = "The Girl on the train",
                    Price = 10
                },

                new Item
                {
                    Id = 2,
                    Type =  ItemType.Membership,
                    Name = "Book Club",
                    Price = 100
                }
            };
            //get selected items
            var selectedItems = (from i in items
                                 join id in itemIds
                                 on i.Id equals id
                                 select i)
                                 .ToList();
            //generate response
            var response = new CreateOrderResponse
            {
                OrderId = DateTime.UtcNow.ToString("hhmmssyyyyMMdd") + "1",
                IsMembershipSubscribed = selectedItems.Any(x => x.Type == ItemType.Membership),
                IsProductPurchased = selectedItems.Any(x => x.Type != ItemType.Membership)
            };
            
            if (response.IsMembershipSubscribed)
            {
                //process membership if subscribed    
            }

            //process order with selected items
            return response;
        }
    }
}
