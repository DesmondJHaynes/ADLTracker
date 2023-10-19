const _api = "/api/patientprofile";

export const getPatientProfileList = () => {
  return fetch(_api).then((res) => res.json());
};
export const getPatientById = (id) => {
  return fetch(`${_api}/${id}`).then((res) => res.json());
};
