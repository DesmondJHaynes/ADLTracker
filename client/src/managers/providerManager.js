const _api = "/api/provider";

export const getProviderList = () => {
  return fetch(_api).then((res) => res.json());
};
export const getProviderById = (id) => {
  return fetch(`${_api}/${id}`).then((res) => res.json());
};

//Probably won't be necessary...unless I want to implement a messaging system...
