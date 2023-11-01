import { useState } from "react";

export const LastWeight = ({
  patientProfile,
  weight,
  setWeight,
  updateWeight,
  handleChange,
}) => {
  const [accordianOpen, setaccordianOpen] = useState(false);

  function toggleAccordian() {
    setaccordianOpen(!accordianOpen);
  }

  return (
    <section className="last-weight">
      <div className="last-weight-display flexRow">
        <p>Last Weight : {patientProfile.weight} kg</p>
        <button onClick={toggleAccordian} className="update-card-button">
          {accordianOpen ? (
            <img src="https://cdn-icons-png.flaticon.com/128/7268/7268569.png" />
          ) : (
            <img src="https://cdn-icons-png.flaticon.com/128/3524/3524388.png" />
          )}
        </button>
      </div>

      <div className={`accordian ${accordianOpen ? "reveal" : ""}`}>
        <div className="input-lastweight left flexRow">
          <input
            value={weight}
            type="number"
            placeholder={`${patientProfile.weight} kg`}
            onChange={(e) => {
              setWeight(e.target.value);
            }}
            onKeyDown={(e) =>
              e.key === "Enter"
                ? handleChange("weight", weight, updateWeight).then(() =>
                    setWeight("")
                  )
                : null
            }
          />{" "}
          <button
            name="weight"
            onClick={(e) => {
              handleChange("weight", weight, updateWeight).then(() =>
                setWeight("")
              );
            }}
          >
            <img src="https://cdn-icons-png.flaticon.com/128/1828/1828643.png" />
          </button>
          <button
            onClick={() => {
              setWeight("");
              toggleAccordian();
            }}
          >
            <img src="https://cdn-icons-png.flaticon.com/128/1632/1632708.png" />
          </button>
        </div>
      </div>
    </section>
  );
};
