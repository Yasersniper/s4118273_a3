using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentA3.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string BookID { get; set; } = string.Empty;

    public int AuthorID { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateOnly PublishedDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [ForeignKey(nameof(AuthorID))]
    public Author Author { get; set; } = null!;

    public ICollection<Borrow> Borrows { get; set; }
        = new List<Borrow>();
}