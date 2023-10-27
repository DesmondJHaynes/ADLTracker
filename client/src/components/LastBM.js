import { useState } from "react";
import { updateLastBM } from "../managers/patientProfileManager.js";
export const LastBM = ({patientProfile, formatDate, lastBM, setLastBM, today, handleChange}) => {
    const [accordianOpen, setaccordianOpen] = useState(false);

    function toggleAccordian()
    {setaccordianOpen(!accordianOpen)}

    return(
        <section className="last-weight">
              <div className="last-weight-display flexRow">
                <p>Last BM : {formatDate(patientProfile.lastBM)}</p>
                <button onClick={toggleAccordian} className="update-card-button">
                    <img src="https://cdn-icons-png.flaticon.com/128/3524/3524388.png"/>
                </button>
              </div>
              
              <div className={`accordian ${accordianOpen? "reveal" : ''}`}>
                <div className="input-lastweight lastBath-input left flexRow">
                  <input
                    value={lastBM}
                    type="date"
                    max={today}
                    onChange={(e) => {
                      setLastBM(e.target.value);
                    }}
                  />{" "}
                  <button
                    onClick={(e) => {
                      handleChange(
                        "lastBM",
                        lastBM,
                        updateLastBM
                      ).then(() => setLastBM(""));
                    }}
                  >
                    <img src="https://cdn-icons-png.flaticon.com/128/1828/1828643.png"/>
                  </button>
                  <button onClick={() => {
                    setLastBM("");
                    toggleAccordian();}}><img src="https://cdn-icons-png.flaticon.com/128/1632/1632708.png"/></button>
                </div>
              </div>
            </section>
    )
}