using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DTOs.UserItems
{
    public record CreateUserItemDTO
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
    }
}
