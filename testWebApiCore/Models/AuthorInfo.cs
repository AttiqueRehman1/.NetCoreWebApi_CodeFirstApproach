using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace testWebApiCore.Models
{
    public class AuthorInfo
    {
        public int AuthorInfoId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNubmer { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

    }
}
