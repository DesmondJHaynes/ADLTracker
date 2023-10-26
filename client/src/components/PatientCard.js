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
  setToggleProfile,
  toggleProfile,
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
      className={`patient--card flexRow ${
        assignedPatients.some((ap) => ap.patientProfileId === patient.id)
          ? "assigned-pt"
          : ""
      }`}
      onClick={(e) => {
        e.stopPropagation();
        getPatientById(patient.id).then((res) => setPatientProfile(res));
        if (!toggleProfile) {
          setToggleProfile(!toggleProfile);
        }
      }}
    >
      <div className="patient-shortinfo--card left">
        <p>R. {patient.roomNumber}</p>
        <p>
          {patient.patient.lastName} {patient.patient.firstName[0]}. |{" "}
          {patient.patient.age}/{patient.patient.gender.simple} <br />
        </p>
        <p>Dx: {patient.diagnosis}</p>
      </div>
      {patient.contactPrecaution.id !== 1 ? (
        <div className="precaution-tag--simple flexCol">
          <img
            class="card-icon caution"
            src="https://static.thenounproject.com/png/4564847-200.png"
          ></img>
        </div>
      ) : (
        <div></div>
      )}
      {patient.fallRisk === true ? (
        <div className="fall-tag--simple flexCol">
          <img
            class="card-icon"
            src="https://thenounproject.com/api/private/icons/4498028/edit/?backgroundShape=SQUARE&backgroundShapeColor=%23000000&backgroundShapeOpacity=0&exportSize=752&flipX=false&flipY=false&foregroundColor=%23000000&foregroundOpacity=1&imageFormat=png&rotation=0"
          ></img>
        </div>
      ) : (
        <div className="fall-tag--holder"></div>
      )}
      <div className="card-assigner">
        {assignedPatients.some((ap) => ap.patientProfileId === patient.id) ? (
          <button
            className="remove-pt"
            onClick={(e) => {
              e.stopPropagation();
              handleUnassign();
            }}
          >
            -
          </button>
        ) : (
          <button
            className="add-pt"
            onClick={(e) => {
              e.stopPropagation();
              handleAssign();
            }}
          >
            +
          </button>
        )}
      </div>
    </div>
  );
};
