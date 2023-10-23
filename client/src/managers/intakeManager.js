const _apiUrl = "/api/intake";

export const getIntakes = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const AddIntake = (obj) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(obj),
  }).then((res) => res.json());
};
