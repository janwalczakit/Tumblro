using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblro
{

    public class Blog
    {
        public bool ask { get; set; }
        public bool ask_anon { get; set; }
        public string ask_page_title { get; set; }
        public bool asks_allow_media { get; set; }
        public IList<Avatar> avatar { get; set; }
        public bool can_chat { get; set; }
        public bool can_subscribe { get; set; }
        public string description { get; set; }
        public bool is_nsfw { get; set; }
        public string name { get; set; }
        public int posts { get; set; }
        public bool share_likes { get; set; }
        public bool subscribed { get; set; }
        public Theme theme { get; set; }
        public string title { get; set; }
        public int total_posts { get; set; }
        public int updated { get; set; }
        public string url { get; set; }
        public string uuid { get; set; }
        public bool is_optout_ads { get; set; }
    }
}
