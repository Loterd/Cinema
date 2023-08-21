using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Cinema.Models;

public class Theater: BaseModel
{
    [Column("name")]
    public string Name { get; set; }
    
    [Column("seating_arrangement")]
    public string SeatingArrangementJson { get; set; }

    [NotMapped]
    public SeatArrangement[][] SeatingArrangement
    {
        get => JsonConvert.DeserializeObject<SeatArrangement[][]>(SeatingArrangementJson);
        set => SeatingArrangementJson = JsonConvert.SerializeObject(value);
    }
}

public enum SeatArrangement
{
    UnAvailable = 0,
    Available = 1,
    Reserved = 2,
    Booked = 3,
}