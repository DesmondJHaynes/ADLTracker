const _apiURl = "/api/contactprecaution"

export const getContactPrecautionList = () => {
    return fetch(_apiURl).then((res) => res.json())
}