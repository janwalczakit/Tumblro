using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblro
{
    /// <summary>Class <c>Data</c> is first tag from tumblr json file</summary>
    ///
    public class Data
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }
}
