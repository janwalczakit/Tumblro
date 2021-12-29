using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tumblro
{
    public class HelpMethods
    {
        /// <summary>
        /// Checks if blogname exist on tumblr
        /// </summary>
        /// <param name="BlogName">Name of blog</param>
        /// <returns>bool</returns>
        public async static Task<bool> CheckIfBlogExistsAsync(string BlogName)
        {

            using (var client = new HttpClient())
            {

                try
                {
                    string URL = "https://api.tumblr.com/v2/blog/" + BlogName.ToLower() + ".tumblr.com/info?api_key=" + Constants.ApiKey;

                    HttpResponseMessage response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {

                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.Message;
                    return false;
                }
            }
        }
    }
}
