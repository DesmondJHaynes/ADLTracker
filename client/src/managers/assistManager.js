const _apiUrl = "/api/assisttype";

export const getAssistTypes = () => {
  return fetch(_apiUrl).then((res) => res.json());
};
