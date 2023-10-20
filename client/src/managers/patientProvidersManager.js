const _apiUrl = "/api/PatientProvider";

export const getPatientProviders = () => {
  return fetch(_apiUrl).then((res) => res.json());
};
export const CreatePatientProviders = (ppObj) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(ppObj),
  }).then((res) => res.json());
};
export const DeletePatientProviders = async (userId, patientId) => {
  await fetch(`${_apiUrl}/${patientId}?userId=${userId}`, { method: "DELETE" });
};
