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
  const [toggleProfile, setToggleProfile] = useState(false);

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
      <div
        className="container--patients flexCol center"
        onClick={(e) => {
          setToggleProfile(false);
        }}
      >
        <PatientList
          patientList={patientList}
          setToggleProfile={setToggleProfile}
          toggleProfile={toggleProfile}
          setPatientProfile={setPatientProfile}
          assignedPatients={assignedPatients}
          setPatientProvider={setPatientProvider}
          userId={user.id}
        />
      </div>
      <div
        className="container--patientProfiles center"
        onClick={(e) => {
          setToggleProfile(false);
        }}
      >
        <UserNav user={user} setLoggedInUser={setLoggedInUser} />
        <div className="placeholder-image">
          <h2 className="placeholder-text">
            Select A Patient <br />
            To Get Started
          </h2>
          <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Bimetrical_icon_clipboard_black.svg/1200px-Bimetrical_icon_clipboard_black.svg.png" />
        </div>
        <PatientProfileCard
          userId={user.id}
          toggleProfile={toggleProfile}
          patientProvider={patientProvider}
          patientProfile={patientProfile}
          refreshProfile={refreshProfile}
        />
      </div>
    </div>
  );
};
