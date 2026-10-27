using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentA3.Models;

public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuthorID { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}