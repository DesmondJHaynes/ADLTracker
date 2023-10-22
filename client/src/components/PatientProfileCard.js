import { useState } from "react";
import {
  Button,
  Col,
  Input,
  Label,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Row,
} from "reactstrap";
import {
  updateLastBM,
  updateLastBath,
  updateTelemetry,
  updateWeight,
} from "../managers/patientProfileManager.js";

export const PatientProfileCard = ({ patientProfile, refreshProfile }) => {
  const [weight, setWeight] = useState("");
  const [lastBath, setLastBath] = useState("");
  const [lastBM, setLastBM] = useState("");
  const [modalRemoveTele, setModalRemoveTele] = useState(false);
  const [modalNewTele, setModalNewTele] = useState(false);
  const [boxNumber, setBoxNumber] = useState("");

  if (!patientProfile) {
    return (
      <>
        <div className="defineShape">such empty</div>
      </>
    );
  }

  const today = new Date().toLocaleDateString("fr-ca");

  const toggle = (setter, modal) => setter(!modal);

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

  async function handleRemoveTele() {
    const clone = structuredClone(patientProfile);
    clone.telemetry = false;
    clone.telemetryNumber = null;
    console.log(clone);
    await updateTelemetry(patientProfile.id, clone);
    await refreshProfile(patientProfile.id);
    toggle(setModalRemoveTele, modalRemoveTele);
  }
  async function handleNewTele(boxNumber) {
    const clone = structuredClone(patientProfile);
    clone.telemetry = true;
    clone.telemetryNumber = parseInt(boxNumber);
    console.log(clone);
    await updateTelemetry(patientProfile.id, clone);
    await refreshProfile(patientProfile.id);
    setBoxNumber("");
    toggle(setModalNewTele, modalNewTele);
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
              <br />❌
              <input
                type="range"
                max={"1"}
                value={patientProfile.telemetry === true ? "1" : "0"}
                onChange={(e) => {
                  e.target.value === "0"
                    ? toggle(setModalRemoveTele, modalRemoveTele)
                    : toggle(setModalNewTele, modalNewTele);
                }}
              ></input>
              {patientProfile.telemetry
                ? `💟#${patientProfile.telemetryNumber}`
                : `💟`}
              <Modal
                isOpen={modalRemoveTele}
                toggle={() => toggle(setModalRemoveTele, modalRemoveTele)}
              >
                <ModalHeader
                  toggle={() => toggle(setModalRemoveTele, modalRemoveTele)}
                >
                  Are You Sure?
                </ModalHeader>
                <ModalBody>
                  <p>
                    Are you sure want to remove{" "}
                    {patientProfile.patient.lastName},{" "}
                    {patientProfile.patient.firstName} from Telemetry
                    monitoring? Be sure there's an order for removal!
                  </p>
                </ModalBody>
                <ModalFooter>
                  <Button color="danger" onClick={handleRemoveTele}>
                    Remove Tele
                  </Button>{" "}
                  <Button
                    color="secondary"
                    onClick={() => toggle(setModalRemoveTele, modalRemoveTele)}
                  >
                    Cancel
                  </Button>
                </ModalFooter>
              </Modal>
              <Modal
                isOpen={modalNewTele}
                toggle={() => toggle(setModalNewTele, modalNewTele)}
              >
                <ModalHeader
                  toggle={() => toggle(setModalNewTele, modalNewTele)}
                >
                  New Tele Box
                </ModalHeader>
                <ModalBody>
                  <p>Please enter the 3-Digit Telemetry Box# below</p>
                  <Label htmlFor="telemetry">Box #</Label>
                  <Input
                    type="number"
                    value={boxNumber}
                    placeholder="000"
                    max="999"
                    onChange={(e) => setBoxNumber(e.target.value)}
                  />
                </ModalBody>
                <ModalFooter>
                  <Button
                    color="success"
                    onClick={() => handleNewTele(boxNumber)}
                  >
                    Add Tele
                  </Button>{" "}
                  <Button
                    color="secondary"
                    onClick={() => toggle(setModalNewTele, modalNewTele)}
                  >
                    Cancel
                  </Button>
                </ModalFooter>
              </Modal>
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
