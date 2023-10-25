const _apiUrl = "/api/output";

export const getOutputs = (ppId) => {
  return fetch(`${_apiUrl}/${ppId}`).then((res) => res.json());
};

export const AddOutput = (obj) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(obj),
  }).then((res) => res.json());
};

export const DeleteOutput = async (id) => {
  return await fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  });
};
