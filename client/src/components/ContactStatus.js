import { Button } from "reactstrap";

export const ContactStatus = ({
  patientProfile,
  setModalRemoveContact,
  modalRemoveContact,
  setModalInfo,
  modalInfo,
  setInfo,
  toggle,
}) => {
  return (
    <div className="contact">
      {patientProfile.contactPrecaution.id === 1 ? (
        <div className="standard-precautions">
          <h3 className="standard">Standard Precautions</h3>
          <div className="contact-info">
            <img
              onClick={() => {
                setInfo(patientProfile.contactPrecaution);
                toggle(setModalInfo, modalInfo);
              }}
              className={"info-image"}
              src="https://cdn-icons-png.flaticon.com/128/157/157933.png"
            />
          </div>
        </div>
      ) : (
        <>
          <h3 className="precaution">Contact Precaution</h3>
          <div className="contact-info">
            <div className="contact-title">
              {patientProfile.contactPrecaution.type}
            </div>
            <img
              onClick={() => {
                setInfo(patientProfile.contactPrecaution);
                toggle(setModalInfo, modalInfo);
              }}
              className={"info-image"}
              src="https://cdn-icons-png.flaticon.com/128/157/157933.png"
            />
          </div>
        </>
      )}

      <button
        className="update-button"
        onClick={() => toggle(setModalRemoveContact, modalRemoveContact)}
      >
        Update
      </button>
    </div>
  );
};
