using System.Collections;
using testWebApiCore.Models;

namespace testWebApiCore.DTO_Models
{
    public class AuhhorInfo_BookInfo
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<BookDTO> Books { get; set; }

    }
}
