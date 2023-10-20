namespace ADLTracker.Models;

public class PatientProvider
{
    public int Id { get; set; }
    public int PatientProfileId { get; set; }
    public PatientProfile? PatientProfile { get; set; }
    public int ProviderId { get; set; }
    public Provider? Provider { get; set; }
}