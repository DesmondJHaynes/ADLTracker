namespace ADLTracker.Models;

public class Output
{
    public int Id { get; set; }
    public int PatientProfileId { get; set; }
    public int OutputAmount { get; set; }
    public DateTime TimeRecorded { get; set; }

}