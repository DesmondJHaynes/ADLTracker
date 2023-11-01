import { useState } from "react";

export const AssignedProviders = ({ patientProvider, patientProfile }) => {
  const [accordianOpen, setaccordianOpen] = useState(false);

  function toggleAccordian() {
    setaccordianOpen(!accordianOpen);
  }

  return (
    <section className="assigned-providers">
      <button className="" onClick={toggleAccordian}>
        Assigned Providers
        {accordianOpen ? (
          <img
            className="size-down"
            src="https://cdn-icons-png.flaticon.com/128/7268/7268569.png"
          />
        ) : (
          <img src="https://cdn-icons-png.flaticon.com/128/9126/9126125.png" />
        )}
      </button>
      <div
        onClick={toggleAccordian}
        className={`accordian ${accordianOpen ? "reveal" : ""}`}
      >
        <div>
          <ul className="left">
            {patientProvider.map((pp) => {
              if (pp.patientProfileId === patientProfile.id) {
                return (
                  <li key={`provider--${pp.providerId}`} value={pp.providerId}>
                    {pp.provider.lastName}, {pp.provider.firstName}
                  </li>
                );
              }
            })}
          </ul>
        </div>
      </div>
    </section>
  );
};
