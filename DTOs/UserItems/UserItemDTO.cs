using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DTOs.UserItems
{
    public record UserItemDTO
    {
        public int userId { get; set; }
        public string userName { get; set; } = default!;
        public int itemId { get; set; }
        public string itemName { get; set; } = default!;
    }
}
