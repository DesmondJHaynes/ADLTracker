import { useState } from "react";

export const TotalIntake = ({patientProfile, intake, setIntake, handleIntake, getIntakes, setIntakeList, modalIntake, setModalIntake, toggle}) => {
    const [accordianOpen, setaccordianOpen] = useState(false);

    function toggleAccordian()
    {setaccordianOpen(!accordianOpen)}

    return(
        <section className="last-weight">
              <div className="last-weight-display flexRow">
                <p>Total Intake(24hr) :{patientProfile.totalIntake} mL</p>
                <button onClick={toggleAccordian} className="update-card-button">
                    <img src="https://cdn-icons-png.flaticon.com/128/3524/3524388.png"/>
                </button>
              </div>

              <div className={`accordian ${accordianOpen? "reveal" : ''}`}>
                <div className="input-lastweight left flexRow">
                  <input
                    type="number"
                    value={intake}
                    placeholder="0 mL"
                    onChange={(e) => setIntake(e.target.value)}
                  />
                  <button
                    onClick={() => {
                      handleIntake(intake);
                    }}
                  >
                    <img src="https://cdn-icons-png.flaticon.com/128/1828/1828643.png"/>
                  </button>
                  <button onClick={() => {setIntake(""); toggleAccordian();}}><img src="https://cdn-icons-png.flaticon.com/128/1632/1632708.png"/></button>
                  </div>
              </div>
                  <button className="detailed-view-button"
                    onClick={() => {
                      getIntakes(patientProfile.id)
                        .then(setIntakeList)
                        .then(() => toggle(setModalIntake, modalIntake));
                    }}
                  >
                    Detailed View
                  </button>
            </section>
    )
}