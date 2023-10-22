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
export const updateLastBath = (id, obj) => {
  return fetch(`${_api}/${id}/bath`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(obj),
  });
};
export const updateLastBM = (id, obj) => {
  return fetch(`${_api}/${id}/bm`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(obj),
  });
};
