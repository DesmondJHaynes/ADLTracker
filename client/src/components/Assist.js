import { Button } from "reactstrap";

export const Assist = ({
  patientProfile,
  toggle,
  setModalAssist,
  modalAssist,
}) => {
  return (
    <div className="assist">
      {patientProfile.assistTypeId > 1 ? (
        <>
          <h3 className="fall-risk">Fall Risk</h3>
          <div>{patientProfile.assistType.type}</div>
        </>
      ) : (
        <h3>{patientProfile.assistType.type}</h3>
      )}
      <button
        className="update-button"
        onClick={() => toggle(setModalAssist, modalAssist)}
      >
        Update
      </button>
    </div>
  );
};
