const _apiUrl = "/api/intake";

export const getIntakes = (ppId) => {
  return fetch(`${_apiUrl}/${ppId}`).then((res) => res.json());
};

export const AddIntake = (obj) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(obj),
  }).then((res) => res.json());
};

export const DeleteIntake = async (id) => {
  return await fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  });
};
