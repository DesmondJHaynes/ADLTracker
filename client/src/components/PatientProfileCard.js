import { useEffect, useState } from "react";
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
  Table,
} from "reactstrap";
import {
  updateAssistType,
  updateContactPrecuation,
  updateLastBM,
  updateLastBath,
  updateTelemetry,
  updateWeight,
} from "../managers/patientProfileManager.js";
import { getContactPrecautionList } from "../managers/contactPrecautionManager.js";
import { getAssistTypes } from "../managers/assistManager.js";
import {
  AddOutput,
  DeleteOutput,
  getOutputs,
} from "../managers/outputManager.js";
import {
  AddIntake,
  DeleteIntake,
  getIntakes,
} from "../managers/intakeManager.js";
import { AssignedProviders } from "./AssignedProviders.js";
import { LastWeight } from "./LastWeight.js";
import { LastBath } from "./LastBath.js";
import { LastBM } from "./LastBM.js";
import { TotalIntake } from "./TotalIntake.js";
import { TotalOutput } from "./TotalOutput.js";
import { Telemetry } from "./Telemetry.js";
import { Assist } from "./Assist.js"
import { ContactStatus } from "./ContactStatus.js";

export const PatientProfileCard = ({
  patientProfile,
  refreshProfile,
  userId,
  patientProvider,
  toggleProfile,
}) => {
  const [CPList, setCPList] = useState([]);
  const [assistList, setAssistList] = useState([]);
  const [assistId, setAssistId] = useState("");
  const [contactId, setContactId] = useState("");
  const [weight, setWeight] = useState("");
  const [lastBath, setLastBath] = useState("");
  const [lastBM, setLastBM] = useState("");
  const [intake, setIntake] = useState("");
  const [intakeList, setIntakeList] = useState("");
  const [output, setOutput] = useState("");
  const [outputList, setOutputList] = useState("");
  const [info, setInfo] = useState();

  const [modalInfo, setModalInfo] = useState(false);
  const [modalIntake, setModalIntake] = useState(false);
  const [modalOutput, setModalOutput] = useState(false);
  const [modalRemoveTele, setModalRemoveTele] = useState(false);
  const [modalNewTele, setModalNewTele] = useState(false);
  const [modalRemoveContact, setModalRemoveContact] = useState(false);
  const [modalNewContact, setModalNewContact] = useState(false);
  const [modalAssist, setModalAssist] = useState(false);
  const [boxNumber, setBoxNumber] = useState("");

  useEffect(() => {
    getContactPrecautionList().then(setCPList);
    getAssistTypes().then(setAssistList);
  }, []);

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
  function formatTime(dateTime) {
    const timeOnly = dateTime.split("T")[1];
    const [hours, minutes] = timeOnly.split(":");
    return `${hours}:${minutes}`;
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

  async function handleOutput(output) {
    const obj = {
      patientProfileId: patientProfile.id,
      providerId: userId,
      outputAmount: output,
    };
    await AddOutput(obj);
    await refreshProfile(patientProfile.id);
    setOutput("");
  }
  async function handleIntake(intake) {
    const obj = {
      patientProfileId: patientProfile.id,
      providerId: userId,
      intakeAmount: intake,
    };
    await AddIntake(obj);
    await refreshProfile(patientProfile.id);
    setIntake("");
  }

  async function handleIntakeDelete(id) {
    await DeleteIntake(id);
    getIntakes(patientProfile.id).then(setIntakeList);
  }
  async function handleOutputDelete(id) {
    await DeleteOutput(id);
    getOutputs(patientProfile.id).then(setOutputList);
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
      <div
        className={`defineShape ${toggleProfile ? "open-card" : ""}`}
        onClick={(e) => e.stopPropagation()}
      >
        <header className="ppcard--header flexRow">
          <div>
            <h2>R. {patientProfile.roomNumber}</h2>
            <h2 className="codestatus">{patientProfile.codeStatus.type}</h2>
          </div>

          <div className="divider"></div>

          <div className="left">
            <h2>
              {patientProfile.patient.lastName},{" "}
              {patientProfile.patient.firstName}
            </h2>
            <p><span className="bold">DOB:</span> {formatDate(patientProfile.patient.dob)}</p>
            <p>
            <span className="bold">{patientProfile.patient.age}/
              {patientProfile.patient.gender.simple}</span>
            </p>
            <p><span className="bold">Dx:</span> {patientProfile.diagnosis} </p>
            <p><span className="bold">Admit:</span> {formatDate(patientProfile.admissionDate)} </p>
          </div>

          <div>
            {patientProfile.contactPrecaution.id === 1 ? (
              <div></div>
            ) : (
              <div className="precaution-tag--simple flexCol">
          <img
            className="card-icon caution"
            src="https://static.thenounproject.com/png/4564847-200.png"
          ></img>
        </div>
            )}
            {patientProfile.fallRisk === true ? (
              <div className="fall-tag--simple flexCol">
              <img
                className="card-icon"
                src="https://thenounproject.com/api/private/icons/4498028/edit/?backgroundShape=SQUARE&backgroundShapeColor=%23000000&backgroundShapeOpacity=0&exportSize=752&flipX=false&flipY=false&foregroundColor=%23000000&foregroundOpacity=1&imageFormat=png&rotation=0"
                ></img>
            </div>
            ) : (
              <div className="fall-tag--holder"></div>
              )}
          </div>
        </header>
        <Row>
          <Col>
            <AssignedProviders patientProvider={patientProvider} patientProfile={patientProfile} />
            <LastWeight patientProfile={patientProfile} weight={weight} setWeight={setWeight} updateWeight={updateWeight} handleChange={handleChange} />
            <LastBath patientProfile={patientProfile} lastBath={lastBath} setLastBath={setLastBath} handleChange={handleChange} today={today} formatDate={formatDate}/>
            <LastBM patientProfile={patientProfile} lastBM={lastBM} setLastBM={setLastBM} handleChange={handleChange} today={today} formatDate={formatDate}/>
            <TotalIntake patientProfile={patientProfile} intake={intake} setIntake={setIntake} handleIntake={handleIntake} getIntakes={getIntakes} setIntakeList={setIntakeList} ModalIntake={modalIntake} setModalIntake={setModalIntake} toggle={toggle} />
            <TotalOutput patientProfile={patientProfile} output={output} setOutput={setOutput} handleOutput={handleOutput} getOutputs={getOutputs} setOutputList={setOutputList} ModalOutput={modalOutput} setModalOutput={setModalOutput} toggle={toggle} />
          </Col>
          <Col>
            {/* <div className="contact">
              {patientProfile.contactPrecaution.id === 1 ? <h3 className="standard">Standard Precautions</h3> 
              :<><h3 className="precaution">Contact Precaution</h3><div>{patientProfile.contactPrecaution.type}</div></>}
              
              <Button
                onClick={() =>
                  toggle(setModalRemoveContact, modalRemoveContact)
                }
              >
                Update
              </Button>
            </div> */}
              <ContactStatus patientProfile={patientProfile} setModalInfo={setModalInfo} modalInfo={modalInfo} setInfo={setInfo} setModalRemoveContact={setModalRemoveContact} modalRemoveContact={modalRemoveContact} toggle={toggle}/>
              <Assist patientProfile={patientProfile} setModalAssist={setModalAssist} modalAssist={modalAssist} toggle={toggle}/>
              <Telemetry patientProfile={patientProfile} setModalRemoveTele={setModalRemoveTele} setModalNewTele={setModalNewTele} toggle={toggle}/>
          </Col>
        </Row>
      </div>
      <Modal
        isOpen={modalIntake}
        toggle={() => toggle(setModalIntake, modalIntake)}
        onClick={(e) => e.stopPropagation()}
      >
        <ModalHeader toggle={() => toggle(setModalIntake, modalIntake)}>
          Details!
        </ModalHeader>
        <ModalBody>
          {intakeList ? (
            <Table>
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Time</th>
                  <th>Amount</th>
                </tr>
              </thead>
              <tbody>
                {intakeList.map((i) => (
                  <tr key={`intake--${i.id}`}>
                    <td>{formatDate(i.timeRecorded)}</td>
                    <td>{formatTime(i.timeRecorded)}</td>
                    <td>{i.intakeAmount} mL</td>
                    <td>
                      {i.providerId === userId ? (
                        <Button
                          color="danger"
                          onClick={() => handleIntakeDelete(i.id)}
                        >
                          x
                        </Button>
                      ) : (
                        <></>
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          ) : (
            <></>
          )}
        </ModalBody>
      </Modal>
      <Modal
        isOpen={modalOutput}
        toggle={() => toggle(setModalOutput, modalOutput)}
        onClick={(e) => e.stopPropagation()}
      >
        <ModalHeader toggle={() => toggle(setModalOutput, modalOutput)}>
          Details!
        </ModalHeader>
        <ModalBody>
          {outputList ? (
            <Table>
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Time</th>
                  <th>Amount</th>
                </tr>
              </thead>
              <tbody>
                {outputList.map((o) => (
                  <tr key={`output--${o.id}`}>
                    <td>{formatDate(o.timeRecorded)}</td>
                    <td>{formatTime(o.timeRecorded)}</td>
                    <td>{o.outputAmount} mL</td>
                    <td>
                      {o.providerId === userId ? (
                        <Button
                          color="danger"
                          onClick={() => handleOutputDelete(o.id)}
                        >
                          x
                        </Button>
                      ) : (
                        <></>
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          ) : (
            <></>
          )}
        </ModalBody>
      </Modal>

      <Modal
        isOpen={modalRemoveContact}
        toggle={() => toggle(setModalRemoveContact, modalRemoveContact)}
        onClick={(e) => e.stopPropagation()}
      >
        <ModalHeader
          toggle={() => toggle(setModalRemoveContact, modalRemoveContact)}
        >
          Are You Sure?
        </ModalHeader>
        <ModalBody>
          <p>
            Are you sure want to change {patientProfile.patient.lastName},{" "}
            {patientProfile.patient.firstName}'s contact status of{" "}
            {patientProfile.contactPrecaution.type}?
          </p>
        </ModalBody>
        <ModalFooter>
          <Button
            color="danger"
            onClick={() => {
              toggle(setModalRemoveContact, modalRemoveContact);
              toggle(setModalNewContact, modalNewContact);
            }}
          >
            Yes, Update
          </Button>{" "}
          <Button
            color="secondary"
            onClick={() => toggle(setModalRemoveContact, modalRemoveContact)}
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>

      <Modal
        isOpen={modalNewContact}
        toggle={() => toggle(setModalNewContact, modalNewContact)}
        onClick={(e) => e.stopPropagation()}
      >
        <ModalHeader toggle={() => toggle(setModalNewContact, modalNewContact)}>
          Place in contact precautions?
        </ModalHeader>
        <ModalBody>
          <p>Please select a Contact Type Listed Below</p>
          {CPList.map((cp) => (
              <div className="contact-options" key={cp.id}>
                <Input
                  value={cp.id}
                  type="radio"
                  name="contactPrecautionId"
                  onChange={(e) => {
                    setContactId(e.target.value);
                  }}
                />{" "}
                {cp.type}
                <img onClick={() => {
                  setInfo(cp);
                  toggle(setModalInfo, modalInfo);
                }}className={'info-image'} src="https://cdn-icons-png.flaticon.com/128/157/157933.png"/>
              </div>
          ))}
        </ModalBody>
        <ModalFooter>
          <Button
            color="success"
            onClick={() =>
              handleChange(
                "contactPrecautionId",
                contactId,
                updateContactPrecuation
              ).then(() => toggle(setModalNewContact, modalNewContact))
            }
          >
            Update
          </Button>{" "}
          <Button
            color="secondary"
            onClick={() => toggle(setModalNewContact, modalNewContact)}
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
      <Modal
        isOpen={modalInfo}
        toggle={() => toggle(setModalInfo, modalInfo)}
        onClick={(e) => e.stopPropagation()}
        info = {info}
      >
          <img src={`${info?.diagram}`}/>
      </Modal>

      <Modal
        isOpen={modalRemoveTele}
        toggle={() => toggle(setModalRemoveTele, modalRemoveTele)}
        onClick={(e) => e.stopPropagation()}
      >
        <ModalHeader toggle={() => toggle(setModalRemoveTele, modalRemoveTele)}>
          Are You Sure?
        </ModalHeader>
        <ModalBody>
          <p>
            Are you sure want to remove {patientProfile.patient.lastName},{" "}
            {patientProfile.patient.firstName} from Telemetry monitoring? Be
            sure there's an order for removal!
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
        onClick={(e) => e.stopPropagation()}
      >
        <ModalHeader toggle={() => toggle(setModalNewTele, modalNewTele)}>
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
          <Button color="success" onClick={() => handleNewTele(boxNumber)}>
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

      <Modal
        isOpen={modalAssist}
        toggle={() => toggle(setModalAssist, modalAssist)}
        onClick={(e) => e.stopPropagation()}
      >
        <ModalHeader toggle={() => toggle(setModalAssist, modalAssist)}>
          Update Assist Level
        </ModalHeader>
        <ModalBody>
          <p>Please select the degree of assistance patient will need.</p>
          {assistList.map((a) => (
            <div key={a.id}>
              <Input
                value={a.id}
                type="radio"
                name="assistId"
                onChange={(e) => {
                  setAssistId(e.target.value);
                }}
              />{" "}
              {a.type}
            </div>
          ))}
        </ModalBody>
        <ModalFooter>
          <Button
            color="success"
            onClick={() =>
              handleChange("assistTypeId", assistId, updateAssistType).then(
                () => toggle(setModalAssist, modalAssist)
              )
            }
          >
            Update
          </Button>{" "}
          <Button
            color="secondary"
            onClick={() => toggle(setModalAssist, modalAssist)}
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
    </>
  );
};
