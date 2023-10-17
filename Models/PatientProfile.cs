namespace ADLTracker.Models;

public class PatientProfile
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int AssistTypeId { get; set; }
    public AssistType AssistType { get; set; }
    public int ContactPrecautionId { get; set; }
    public ContactPrecaution ContactPrecaution { get; set; }
    public int RoomNumber { get; set; }
    public int Height { get; set; }
    public decimal Weight { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime LastBath { get; set; }
    public DateTime LastBM { get; set; }
    public bool Telemetry { get; set; }
    public int? TelemetryNumber { get; set; }

    public bool FallRisk
    {
        get
        {
            if (AssistTypeId == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public bool Discharged { get; set; }

}