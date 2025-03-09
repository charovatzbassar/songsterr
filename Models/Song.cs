using System.ComponentModel.DataAnnotations;

namespace Project_Task.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Lyrics { get; set; }
    }
}
