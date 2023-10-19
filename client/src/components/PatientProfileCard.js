import { useEffect, useState } from "react";
import { getPatientById } from "../managers/patientProfileManager.js";

export const PatientProfileCard = ({ patientProfile }) => {
  if (!patientProfile) {
    return (
      <>
        <div className="defineShape">such empty</div>
      </>
    );
  }

  return (
    <>
      <div className="defineShape">{patientProfile.patient.lastName}</div>
    </>
  );
};
