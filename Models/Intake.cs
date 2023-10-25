namespace ADLTracker.Models;

public class Intake
{
    public int Id { get; set; }
    public int PatientProfileId { get; set; }
    public int ProviderId { get; set; }
    public int IntakeAmount { get; set; }
    public DateTime TimeRecorded { get; set; }

}