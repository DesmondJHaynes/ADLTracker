import { useEffect, useState } from "react";
import { PatientList } from "./PatientList.js";
import { PatientProfileCard } from "./PatientProfileCard.js";
import { getProviderById } from "../managers/providerManager.js";

export const Workspace = ({ patientProfile, setPatientProfile, userId }) => {
  const [provider, setProvider] = useState();

  useEffect(() => {
    console.log(userId);
  }, []);

  return (
    <div className="App-container">
      <div className="container--patients flexCol center">
        <PatientList setPatientProfile={setPatientProfile} />
      </div>
      <div className="container--patientProfiles center">
        <PatientProfileCard patientProfile={patientProfile} />
      </div>
    </div>
  );
};
