namespace BackEnd.Models;

public partial class machine {
    public int ID { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public string? Place { get; set; }

    public virtual ICollection<project> project { get; set; } = [];
}
