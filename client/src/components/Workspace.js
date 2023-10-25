import { useEffect, useState } from "react";
import { PatientList } from "./PatientList.js";
import { PatientProfileCard } from "./PatientProfileCard.js";
import { getPatientProviders } from "../managers/patientProvidersManager.js";
import { Spinner } from "reactstrap";
import {
  getPatientById,
  getPatientProfileList,
} from "../managers/patientProfileManager.js";
import { UserNav } from "./UserNav.js";

export const Workspace = ({ user, setLoggedInUser }) => {
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
      (pp) => pp.providerId === user.id
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
          userId={user.id}
        />
      </div>
      <div className="container--patientProfiles center">
        <UserNav user={user} setLoggedInUser={setLoggedInUser} />
        <PatientProfileCard
          userId={user.id}
          patientProfile={patientProfile}
          refreshProfile={refreshProfile}
        />
      </div>
    </div>
  );
};
