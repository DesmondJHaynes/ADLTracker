import { useEffect, useState } from "react";
import { PatientList } from "./PatientList.js";
import { PatientProfileCard } from "./PatientProfileCard.js";
import { getPatientProviders } from "../managers/patientProvidersManager.js";
import { Spinner } from "reactstrap";
import {
  getPatientById,
  getPatientProfileList,
} from "../managers/patientProfileManager.js";

export const Workspace = ({ userId }) => {
  const [patientProvider, setPatientProvider] = useState([]);
  const [assignedPatients, setAssignedPatients] = useState();
  const [patientProfile, setPatientProfile] = useState();
  const [patientList, setPatientList] = useState();
  const [indicatorChange, setIndicatorChange] = useState(false);

  useEffect(() => {
    getPatientProviders().then(setPatientProvider);
    getPatientProfileList().then(setPatientList);
  }, []);

  useEffect(() => {
    userPatients();
  }, [patientProvider]);

  useEffect(() => {
    getPatientProfileList().then(setPatientList);
  }, [indicatorChange]);

  async function refreshProfile(ppId) {
    getPatientById(ppId)
      .then(setPatientProfile)
      .then(() => setIndicatorChange(!indicatorChange));
  }

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
          patientList={patientList}
          setPatientProfile={setPatientProfile}
          assignedPatients={assignedPatients}
          setPatientProvider={setPatientProvider}
          userId={userId}
        />
      </div>
      <div className="container--patientProfiles center">
        <PatientProfileCard
          patientProfile={patientProfile}
          refreshProfile={refreshProfile}
        />
      </div>
    </div>
  );
};
