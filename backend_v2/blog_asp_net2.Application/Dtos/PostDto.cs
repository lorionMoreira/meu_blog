using blog_asp_net2.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_asp_net2.Application.Dtos
{
    public class PostDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string message { get; set; }

        public IEnumerable<CommentDto> comment { get; set; }
    }
}
