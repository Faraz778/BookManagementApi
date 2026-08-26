using System.ComponentModel.DataAnnotations;    

namespace BookManagementApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a valid author.")]
        public string Author { get; set; }

        [Range(1000, 2100, ErrorMessage = "Please enter a valid year between 1000 and 2100.")]
        public int PublishedYear { get; set; }


    }
}
