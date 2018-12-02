using System.Collections.Generic;
using Newtonsoft.Json;

namespace WEbApiWithAttrCtor.Models
{
    public class Course
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Instructor
        /// </summary>
        [JsonProperty(PropertyName = "instructor")]
        public string Instructor { get; set; }

        /// <summary>
        /// Course students
        /// </summary>
        [JsonProperty(PropertyName = "students")]
        public List<Student> Students { get; set; }
    }
}