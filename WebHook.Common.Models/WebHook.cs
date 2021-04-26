using System;

namespace WebHook.Common.Models
{
    public class WebHook
    {
        /// <summary>
        /// The identifier WebHook
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The Name of the WebHook
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The WebHook URL
        /// </summary>
        public string Url { get; set; }
    }
}
