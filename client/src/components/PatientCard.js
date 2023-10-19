import { useEffect, useState } from "react";
import { Button } from "reactstrap";
import {
  getPatientById,
  getPatientProfileList,
} from "../managers/patientProfileManager.js";

export const PatientCard = ({ patient, setPatientProfile }) => {
  return (
    <div
      className="patient--card flexRow"
      onClick={() => {
        console.log(patient.patient.lastName);
        getPatientById(patient.id).then((res) => setPatientProfile(res));
      }}
    >
      <div className="patient-shortinfo--card left">
        {patient.roomNumber}
        <br />
        {patient.patient.lastName} {patient.patient.firstName}{" "}
        {patient.patient.age}/{patient.patient.gender.simple} <br />
        diagnosis
      </div>
      {patient.contactPrecaution.id === 1 ? (
        <div></div>
      ) : (
        <div className="precaution-tag--simple"></div>
      )}
      {patient.fallRisk === true ? (
        <div className="fall-tag--simple"></div>
      ) : (
        <div></div>
      )}
      <div>icon</div>
    </div>
  );
};
