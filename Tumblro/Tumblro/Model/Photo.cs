using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblro
{
    public class Photo
    {
        public string caption { get; set; }
        public OriginalSize original_size { get; set; }
        public IList<AltSize> alt_sizes { get; set; }
    }
}
