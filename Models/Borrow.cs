using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentA3.Models;

public class Borrow
{
    [Required]
    public string BookID { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateOnly BorrowDate { get; set; }

    public int MemberID { get; set; }

    [ForeignKey(nameof(BookID))]
    public Book Book { get; set; } = null!;

    [ForeignKey(nameof(MemberID))]
    public Member Member { get; set; } = null!;
}