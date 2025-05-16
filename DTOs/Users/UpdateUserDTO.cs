using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DTOs.Users;
    public record UpdateUserDTO
    {
        public string Name { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int Life { get; set; }
        public int Xp { get; set; }
        public int Lvl { get; set; }
        public int Gold { get; set; }
    }
