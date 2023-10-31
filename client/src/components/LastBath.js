import { useState } from "react";
import { updateLastBath } from "../managers/patientProfileManager.js";

export const LastBath = ({patientProfile, formatDate, lastBath, setLastBath, today, handleChange}) => {
    const [accordianOpen, setaccordianOpen] = useState(false);

    function toggleAccordian()
    {setaccordianOpen(!accordianOpen)}

    return(
        <section className="last-weight">
              <div className="last-weight-display flexRow">
                <p>Last Bath : {formatDate(patientProfile.lastBath)}</p>
                <button onClick={toggleAccordian} className="update-card-button">
                    <img src="https://cdn-icons-png.flaticon.com/128/3524/3524388.png"/>
                </button>
              </div>
              
              <div className={`accordian ${accordianOpen? "reveal" : ''}`}>
                <div className="input-lastweight lastBath-input left flexRow">
                  <input
                    value={lastBath}
                    type="date"
                    max={today}
                    onChange={(e) => {
                      setLastBath(e.target.value);
                    }}
                  />{" "}
                  <button
                    onClick={(e) => {
                      handleChange(
                        "lastBath",
                        lastBath,
                        updateLastBath
                      ).then(() => setLastBath(""));
                    }}
                  >
                    <img src="https://cdn-icons-png.flaticon.com/128/1828/1828643.png"/>
                  </button>
                  <button onClick={() => {
                    setLastBath("");
                    toggleAccordian();}}><img src="https://cdn-icons-png.flaticon.com/128/1632/1632708.png"/></button>
                </div>
              </div>
            </section>
    )
}