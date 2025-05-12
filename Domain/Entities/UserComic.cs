using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserComic
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ComicId { get; set; }
    }
}
