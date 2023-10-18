import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Spinner } from "reactstrap";
import { tryGetLoggedInUser } from "./managers/authManager.js";
import ApplicationViews from "./components/ApplicationViews";
import { PatientList } from "./components/PatientList.js";
import { PatientProfileCard } from "./components/PatientProfileCard.js";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();
  const [patientProfile, setPatientProfile] = useState();

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // if (loggedInUser === undefined) {
  //   return <Spinner />;
  // }

  return (
    <>
      <div className="App-container">
        <div className="container--patients flexCol center">
          <PatientList setPatientProfile={setPatientProfile} />
        </div>
        <div className="container--patientProfiles center">
          <PatientProfileCard patientProfile={patientProfile} />
          {/* <ApplicationViews
            loggedInUser={loggedInUser}
            setLoggedInUser={setLoggedInUser}
          /> */}
        </div>
      </div>
    </>
  );
}

export default App;
