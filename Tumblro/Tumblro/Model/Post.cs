using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblro
{
    public class Post
    {
        public string type { get; set; }
        public string blog_name { get; set; }
        public Blog blog { get; set; }
        public object id { get; set; }
        public string id_string { get; set; }
        public string post_url { get; set; }
        public string slug { get; set; }
        public string date { get; set; }
        public int timestamp { get; set; }
        public string state { get; set; }
        public string format { get; set; }
        public string reblog_key { get; set; }
        public IList<string> tags { get; set; }
        public string short_url { get; set; }
        public string summary { get; set; }
        public bool should_open_in_legacy { get; set; }
        public object recommended_source { get; set; }
        public object recommended_color { get; set; }
        public int note_count { get; set; }
        public string source_url { get; set; }
        public string source_title { get; set; }
        public string caption { get; set; }
        public string link_url { get; set; }
        public string image_permalink { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public IList<Photo> photos { get; set; }
        public object title { get; set; }
        public string body { get; set; }
        public string text { get; set; }
        public bool can_like { get; set; }
        public string interactability_reblog { get; set; }
        public bool can_reblog { get; set; }
        public bool can_send_in_message { get; set; }
        public bool can_reply { get; set; }
        public bool display_avatar { get; set; }
    }
}
