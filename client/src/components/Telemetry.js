import { useState } from "react";

export const Telemetry = ({patientProfile, setModalRemoveTele, modalRemoveTele, setModalNewTele, modalNewTele, toggle}) => {

    if (!patientProfile){
        return null
    }
    return(
        <div className="telemetry">
              <div className="telemetry--main">
                <p htmlFor="tele">Telemetry</p>
                <div className="teleSlider">
                {patientProfile.telemetry === true ? <img onClick={() => toggle(setModalRemoveTele, modalRemoveTele)} className='teleImage-x' src="https://cdn-icons-png.flaticon.com/128/1828/1828774.png"/>: <img className='teleImage-x noTele' src="https://cdn-icons-png.flaticon.com/128/1828/1828774.png"/>}
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
                  ? <img className="teleImage" src="https://cdn-icons-png.flaticon.com/128/1818/1818145.png"/>
                  : <img onClick={() => toggle(setModalNewTele, modalNewTele)} className="teleImage noTele" src="https://cdn-icons-png.flaticon.com/128/1818/1818134.png"/>
                }
                </div>
              </div>
              <div className="telemetry--box-number">{patientProfile.telemetry
                  ? <>Box# {patientProfile.telemetryNumber}</>
                  : <></>}
              </div>
            </div>
    )
}