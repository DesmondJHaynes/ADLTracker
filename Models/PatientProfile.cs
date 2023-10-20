namespace ADLTracker.Models;

public class PatientProfile
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public int AssistTypeId { get; set; }
    public AssistType? AssistType { get; set; }
    public int CodeStatusId { get; set; }
    public CodeStatus? CodeStatus { get; set; }
    public int ContactPrecautionId { get; set; }
    public ContactPrecaution? ContactPrecaution { get; set; }
    public string Diagnosis { get; set; }
    public int RoomNumber { get; set; }
    public int Height { get; set; }
    public decimal Weight { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime LastBath { get; set; }
    public DateTime LastBM { get; set; }
    public bool Telemetry { get; set; }
    public int? TelemetryNumber { get; set; }
    public bool Discharged { get; set; }
    public List<Output> Outputs { get; set; }
    public List<Intake> Intakes { get; set; }
    public int TotalIntake
    {
        get
        {
            int total = 0;
            foreach (Intake intake in Intakes)
            {
                total += intake.IntakeAmount;
            }
            return total;
        }

    }
    public int TotalOutput
    {
        get
        {
            int total = 0;
            foreach (Output output in Outputs)
            {
                total += output.OutputAmount;
            }
            return total;
        }

    }
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

}