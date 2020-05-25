using System.Collections.Generic;
using Emmanuel.FunBooksAndVideo.Logic.Enum;
using Emmanuel.FunBooksAndVideo.Logic.Model.CustomerOrder;

namespace Emmanuel.FunBooksAndVideo.Logic.Model.Account
{
    public class CustomerAccount
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CustomerId { get; set; }

        public string Email { get; set; }

        public MembershipType MembershipType { get; set; }

        public List<Book> Books { get; set; }

        public List<Video> Videos { get; set; }
    }
}