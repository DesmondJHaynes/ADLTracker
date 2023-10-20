import { useEffect, useState } from "react";
import { PatientList } from "./PatientList.js";
import { PatientProfileCard } from "./PatientProfileCard.js";
import { getProviderById } from "../managers/providerManager.js";
import { getPatientProviders } from "../managers/patientProvidersManager.js";
import { Spinner } from "reactstrap";

export const Workspace = ({ patientProfile, setPatientProfile, userId }) => {
  const [patientProvider, setPatientProvider] = useState([]);
  const [assignedPatients, setAssignedPatients] = useState();
  const [assignedProviders, setAssignedProviders] = useState([]);

  useEffect(() => {
    getPatientProviders().then(setPatientProvider);
  }, []);

  useEffect(() => {
    userPatients();
  }, [patientProvider]);

  function singlePatientProviders() {}

  function userPatients() {
    const userFilter = patientProvider?.filter(
      (pp) => pp.providerId === userId
    );
    setAssignedPatients(userFilter);
  }

  if (!assignedPatients) {
    return <Spinner />;
  }

  return (
    <div className="App-container">
      <div className="container--patients flexCol center">
        <PatientList
          setPatientProfile={setPatientProfile}
          assignedPatients={assignedPatients}
          setPatientProvider={setPatientProvider}
          userId={userId}
        />
      </div>
      <div className="container--patientProfiles center">
        <PatientProfileCard patientProfile={patientProfile} />
      </div>
    </div>
  );
};
