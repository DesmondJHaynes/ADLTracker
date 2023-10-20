import { Button } from "reactstrap";
import { getPatientById } from "../managers/patientProfileManager.js";
import {
  CreatePatientProviders,
  DeletePatientProviders,
  getPatientProviders,
} from "../managers/patientProvidersManager.js";

export const PatientCard = ({
  patient,
  setPatientProfile,
  assignedPatients,
  setPatientProvider,
  userId,
}) => {
  async function handleAssign() {
    const patientProviderObj = {
      patientProfileId: patient.id,
      providerId: userId,
    };
    await CreatePatientProviders(patientProviderObj);
    const pp = await getPatientProviders();
    setPatientProvider(pp);
  }

  async function handleUnassign() {
    await DeletePatientProviders(userId, patient.id);
    const pp = await getPatientProviders();
    setPatientProvider(pp);
  }

  return (
    <div
      className="patient--card flexRow"
      onClick={() => {
        getPatientById(patient.id).then((res) => setPatientProfile(res));
      }}
    >
      <div className="patient-shortinfo--card left">
        {patient.roomNumber}
        <br />
        {patient.patient.lastName} {patient.patient.firstName}{" "}
        {patient.patient.age}/{patient.patient.gender.simple} <br />
        {patient.diagnosis}
      </div>
      {patient.contactPrecaution.id !== 1 ? (
        <div className="precaution-tag--simple"></div>
      ) : (
        <div></div>
      )}
      {patient.fallRisk === true ? (
        <div className="fall-tag--simple"></div>
      ) : (
        <div></div>
      )}
      <div>
        {assignedPatients.some((ap) => ap.patientProfileId === patient.id) ? (
          <Button
            onClick={() => {
              handleUnassign();
            }}
          >
            Yes
          </Button>
        ) : (
          <Button
            onClick={() => {
              handleAssign();
            }}
          >
            NO
          </Button>
        )}
      </div>
    </div>
  );
};
