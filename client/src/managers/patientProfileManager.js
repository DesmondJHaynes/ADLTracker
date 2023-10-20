const _api = "/api/patientprofile";

export const getPatientProfileList = () => {
  return fetch(_api).then((res) => res.json());
};
export const getPatientById = (id) => {
  return fetch(`${_api}/${id}`).then((res) => res.json());
};

export const updateWeight = (id, obj) => {
  return fetch(`${_api}/${id}/weight`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(obj),
  });
};
