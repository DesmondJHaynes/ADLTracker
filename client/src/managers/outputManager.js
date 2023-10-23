const _apiUrl = "/api/output";

export const getOutputs = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const AddOutput = (obj) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(obj),
  }).then((res) => res.json());
};
