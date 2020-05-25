using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;
using System.Collections.Generic;

namespace Emmanuel.FunBooksAndVideo.Logic.Model
{
    public class ItemLines
    {
        public List<Book> Books { get; set; } 

        public List<Video> Videos { get; set; }

        public MembershipType MembershipType { get; set; }
    }
}
