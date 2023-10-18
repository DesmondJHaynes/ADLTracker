const _api = "/api/patientprofile";

export const getPatientList = () => {
  return fetch(_api).then((res) => res.json());
};
export const getPatientById = (id) => {
  return fetch(`${_api}/id?id=${id}`).then((res) => res.json());
  //There's something wrong with the controller route for sure...
};
