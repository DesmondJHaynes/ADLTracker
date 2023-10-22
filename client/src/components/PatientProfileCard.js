import { useState } from "react";
import { Col, Label, Row } from "reactstrap";
import {
  updateLastBM,
  updateLastBath,
  updateWeight,
} from "../managers/patientProfileManager.js";

export const PatientProfileCard = ({ patientProfile, refreshProfile }) => {
  const [weight, setWeight] = useState("");
  const [lastBath, setLastBath] = useState("");
  const [lastBM, setLastBM] = useState("");

  if (!patientProfile) {
    return (
      <>
        <div className="defineShape">such empty</div>
      </>
    );
  }

  const today = new Date().toLocaleDateString("fr-ca");

  function formatDate(dateTime) {
    const dateOnly = dateTime.split("T")[0];
    const [year, month, date] = dateOnly.split("-");
    return `${month}.${date}.${year.slice(-2)}`;
  }

  async function handleChange(property, value, updateFxn) {
    const clone = structuredClone(patientProfile);
    clone[property] = value;
    await updateFxn(patientProfile.id, clone);
    await refreshProfile(patientProfile.id);
  }

  return (
    <>
      <div className="defineShape">
        <header>
          <div>
            <h2>{patientProfile.roomNumber}</h2>
            <h2>{patientProfile.codeStatus.type}</h2>
          </div>

          <div className="divider"></div>

          <div>
            <h2>
              {patientProfile.patient.lastName},{" "}
              {patientProfile.patient.firstName}
            </h2>
            <p>DOB: {formatDate(patientProfile.patient.dob)}</p>
            <p>
              {patientProfile.patient.age}/
              {patientProfile.patient.gender.simple}
            </p>
            <p>Diagnosis: {patientProfile.diagnosis} </p>
            <p>Admit: {formatDate(patientProfile.admissionDate)} </p>
          </div>

          <div className="absolute">
            {patientProfile.contactPrecaution.id === 1 ? (
              <div></div>
            ) : (
              <div className="precaution-tag--simple"></div>
            )}
            {patientProfile.fallRisk === true ? (
              <div className="fall-tag--simple"></div>
            ) : (
              <div></div>
            )}
          </div>
        </header>
        <Row>
          <Col>
            <div className="inner--container">
              <select>
                <option name={"provider"} value={0}>
                  Assigned Providers
                </option>
              </select>
            </div>
            <div className="inner--container">
              <div>
                <Label htmlFor="lastweight">Last Weight</Label>
                <p name="lastweight">{patientProfile.weight} kg</p>
              </div>
              <div>
                <div className="hidden">
                  <input
                    value={weight}
                    type="number"
                    placeholder={patientProfile.weight}
                    onChange={(e) => {
                      setWeight(e.target.value);
                    }}
                  />{" "}
                  <button
                    name="weight"
                    onClick={(e) => {
                      handleChange(e.target.name, weight, updateWeight).then(
                        () => setWeight("")
                      );
                    }}
                  >
                    ✔️
                  </button>
                  <button>✖️</button>
                </div>
                <div>icon</div>
              </div>
            </div>
            <div className="inner--container">
              {" "}
              <div>
                <Label htmlFor="lastBath">Last Bath</Label>
                <p name="lastBath">{formatDate(patientProfile.lastBath)}</p>
              </div>
              <div>
                <div className="hidden">
                  <input
                    value={lastBath}
                    type="date"
                    max={today}
                    onChange={(e) => {
                      setLastBath(e.target.value);
                    }}
                  />{" "}
                  <button
                    name="lastBath"
                    onClick={(e) => {
                      handleChange(
                        e.target.name,
                        lastBath,
                        updateLastBath
                      ).then(() => setLastBath(""));
                    }}
                  >
                    ✔️
                  </button>
                  <button>✖️</button>
                </div>
                <div>icon</div>
              </div>
            </div>
            <div className="inner--container">
              {" "}
              <div>
                <Label htmlFor="lastBM">Last BM</Label>
                <p name="lastBM">{formatDate(patientProfile.lastBM)}</p>
              </div>
              <div>
                <div className="hidden">
                  <input
                    value={lastBM}
                    type="date"
                    max={today}
                    onChange={(e) => {
                      setLastBM(e.target.value);
                    }}
                  />{" "}
                  <button
                    name="lastBM"
                    onClick={(e) => {
                      handleChange(e.target.name, lastBM, updateLastBM).then(
                        () => setLastBM("")
                      );
                    }}
                  >
                    ✔️
                  </button>
                  <button>✖️</button>
                </div>
                <div>icon</div>
              </div>
            </div>
            <div className="inner--container">
              {" "}
              <div>
                <Label htmlFor="total Intake">Total Intake(24hr)</Label>
                <p name="total Intake">{patientProfile.totalIntake}</p>
              </div>
              <div>
                <div className="hidden">
                  <input type="text" />
                  <button>✔️</button>
                  <button>✖️</button>
                </div>
                <div>icon</div>
              </div>
            </div>
            <div className="inner--container">
              {" "}
              <div>
                <Label htmlFor="total Output">Total Output(24hr)</Label>
                <p name="total Output">{patientProfile.totalOutput}</p>
              </div>
              <div>
                <div className="hidden">
                  <input type="text" />
                  <button>✔️</button>
                  <button>✖️</button>
                </div>
                <div>icon</div>
              </div>
            </div>
          </Col>
          <Col>
            {patientProfile.contactPrecautionId > 1 ? (
              <div className="inner--container">
                <h3>Contact Precaution</h3>
                <div>{patientProfile.contactPrecaution.type}</div>
              </div>
            ) : (
              <></>
            )}
            <div className="inner--container">
              <Label htmlFor="tele">Tele</Label>
              <input type="range" max={"1"}></input>
            </div>
            <div className="inner--container">
              <h3>Assist Level</h3>
              <div>{patientProfile.assistType.type}</div>
              {patientProfile.assistTypeId > 1 ? <div>Fall Risk</div> : <></>}
            </div>
          </Col>
        </Row>
      </div>
    </>
  );
};
