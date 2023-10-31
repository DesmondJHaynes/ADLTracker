import { useState } from "react";

export const TotalOutput = ({patientProfile, output, setOutput, handleOutput, getOutputs, setOutputList, modalOutput, setModalOutput, toggle}) => {
    const [accordianOpen, setaccordianOpen] = useState(false);

    function toggleAccordian()
    {setaccordianOpen(!accordianOpen)}

    return(
        <section className="last-weight">
              <div className="last-weight-display flexRow">
                <p>Total Output(24hr) :{patientProfile.totalOutput} mL</p>
                <button onClick={toggleAccordian} className="update-card-button">
                    <img src="https://cdn-icons-png.flaticon.com/128/3524/3524388.png"/>
                </button>
              </div>

              <div className={`accordian ${accordianOpen? "reveal" : ''}`}>
                <div className="input-lastweight left flexRow">
                  <input
                    type="number"
                    value={output}
                    placeholder="0 mL"
                    onChange={(e) => setOutput(e.target.value)}
                  />
                  <button
                    onClick={() => {
                      handleOutput(output);
                    }}
                  >
                    <img src="https://cdn-icons-png.flaticon.com/128/1828/1828643.png"/>
                  </button>
                  <button onClick={() => {setOutput(""); toggleAccordian();}}><img src="https://cdn-icons-png.flaticon.com/128/1632/1632708.png"/></button>
                  </div>
              </div>
                  <button className="detailed-view-button"
                    onClick={() => {
                      getOutputs(patientProfile.id)
                        .then(setOutputList)
                        .then(() => toggle(setModalOutput, modalOutput));
                    }}
                  >
                    Detailed View
                  </button>
            </section>
    )
}