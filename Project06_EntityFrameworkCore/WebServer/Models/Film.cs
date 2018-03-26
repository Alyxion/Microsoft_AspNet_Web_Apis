using System.ComponentModel.DataAnnotations;

namespace WebServer.Models
{
    public class Film
    {
        [Key]
        public int Film_ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public int Release_Year { get; set; }
    }
}