using System.Text.Json.Serialization;

namespace BackEnd.Models;

public partial class project {
    public int ID { get; set; }

    public int? MachineID { get; set; }

    public DateTime? RecordDateTime { get; set; }

    [JsonIgnore]
    public virtual machine? Machine { get; set; }

    [JsonIgnore]
    public virtual ICollection<data> data { get; set; } = [];
}
