namespace BackEnd.Models;

public partial class data {
    public int ID { get; set; }

    public int? ProjectID { get; set; }

    public double? Speed { get; set; }

    public double? Feed { get; set; }

    public double? XRms { get; set; }

    public double? YRms { get; set; }

    public double? ZRms { get; set; }

    public virtual project? Project { get; set; }
}
