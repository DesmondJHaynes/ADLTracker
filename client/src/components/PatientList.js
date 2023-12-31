import { useEffect, useState } from "react";
import { Button, Spinner } from "reactstrap";
import { PatientCard } from "./PatientCard.js";

export const PatientList = ({
  setPatientProfile,
  assignedPatients,
  setPatientProvider,
  patientList,
  setToggleProfile,
  toggleProfile,
  userId,
}) => {
  const [filteredList, setFilteredList] = useState();
  const [acitveToggle, setActiveToggle] = useState(true);

  useEffect(() => {
    handleFilter(patientList);
  }, [patientList, assignedPatients]);

  function handleFilter() {
    const filtered = [];
    patientList?.map((pp) => {
      assignedPatients.forEach((ap) => {
        if (ap.patientProfileId === pp.id) {
          filtered.push(pp);
        }
      });
    });
    setFilteredList(filtered);
  }

  function handleActiveView(target) {
    if (target.name === "all") {
      setFilteredList(patientList);
      setActiveToggle(false);
    } else if (target.name === "filter") {
      handleFilter(patientList);
      setActiveToggle(true);
    }
  }

  if (!patientList) {
    return <Spinner />;
  }

  return (
    <>
      <div
        className="toggle--patientList"
        onClick={(e) => {
          e.stopPropagation();
        }}
      >
        {acitveToggle ? (
          <>
            <button
              className="allPatients--button toggle--button"
              name={"all"}
              onClick={(e) => handleActiveView(e.target)}
            >
              All Patients
            </button>
            <button
              className="toggle--button myPatients--button selected"
              name={"filter"}
              onClick={(e) => handleActiveView(e.target)}
            >
              My Patients
            </button>
          </>
        ) : (
          <>
            <button
              className="toggle--button allPatients--button selected"
              name={"all"}
              onClick={(e) => handleActiveView(e.target)}
            >
              All Patients
            </button>
            <button
              className="toggle--button myPatients--button"
              name={"filter"}
              onClick={(e) => handleActiveView(e.target)}
            >
              My Patients
            </button>
          </>
        )}
      </div>

      {!acitveToggle ? (
        <div className="cards--patientList scroll">
          {patientList?.map((p) => (
            <div key={p.id}>
              <PatientCard
                setToggleProfile={setToggleProfile}
                toggleProfile={toggleProfile}
                patient={p}
                setPatientProfile={setPatientProfile}
                assignedPatients={assignedPatients}
                setPatientProvider={setPatientProvider}
                userId={userId}
              />
            </div>
          ))}
        </div>
      ) : (
        <div className="cards--patientList scroll">
          {filteredList.length === 0 ? (
            <div>
              <span className="bold">
                No patients assigned to you at this time.
              </span>
              <p>Select a patient from "All Patients" List</p>
            </div>
          ) : (
            filteredList?.map((p) => (
              <div key={p.id}>
                <PatientCard
                  setToggleProfile={setToggleProfile}
                  toggleProfile={toggleProfile}
                  patient={p}
                  setPatientProfile={setPatientProfile}
                  assignedPatients={assignedPatients}
                  setPatientProvider={setPatientProvider}
                  userId={userId}
                />
              </div>
            ))
          )}
        </div>
      )}
    </>
  );
};
