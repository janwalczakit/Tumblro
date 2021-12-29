using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblro
{
    public class Response
    {
        public Blog blog { get; set; }
        public IList<Post> posts { get; set; }
        public int total_posts { get; set; }
    }
}
