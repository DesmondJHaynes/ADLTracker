import { useEffect, useState } from "react";
import { Button, Spinner } from "reactstrap";
import { getPatientList } from "../managers/patientProfileManager.js";
import { PatientCard } from "./PatientCard.js";

export const PatientList = ({ setPatientProfile }) => {
  const [patientList, setPatientList] = useState();
  const [filteredList, setFilteredList] = useState();
  const [acitveToggle, setActiveToggle] = useState(true);

  useEffect(() => {
    getPatientList().then(setPatientList);
  }, []);

  useEffect(() => {
    let clone = structuredClone(patientList);
    clone = clone?.filter((c) => c.telemetry === true);
    setFilteredList(clone);
    // setFilteredList(patientList);
  }, [patientList]);

  function handleActiveView(target) {
    if (target.name === "all") {
      setFilteredList(patientList);
      setActiveToggle(false);
    } else if (target.name === "filter") {
      let clone = structuredClone(patientList);
      clone = clone.filter((c) => c.telemetry === true);
      setFilteredList(clone);
      setActiveToggle(true);
    }
  }

  if (!patientList) {
    return <Spinner />;
  }

  return (
    <>
      <div className="toggle--patientList">
        {acitveToggle ? (
          <>
            <button name={"all"} onClick={(e) => handleActiveView(e.target)}>
              All Patients
            </button>
            <button
              className="selected"
              name={"filter"}
              onClick={(e) => handleActiveView(e.target)}
            >
              My Patients
            </button>
          </>
        ) : (
          <>
            <button
              className="selected"
              name={"all"}
              onClick={(e) => handleActiveView(e.target)}
            >
              All Patients
            </button>
            <button name={"filter"} onClick={(e) => handleActiveView(e.target)}>
              My Patients
            </button>
          </>
        )}
      </div>
      <div className="cards--patientList scroll">
        {filteredList?.map((p) => (
          <div key={p.id}>
            <PatientCard patient={p} setPatientProfile={setPatientProfile} />
          </div>
        ))}
      </div>
    </>
  );
};
