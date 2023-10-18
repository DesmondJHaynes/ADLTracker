import { Routes, Route } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute.js";
import Login from "./auth/Login";
import Register from "./auth/Register";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            // <AuthorizedRoute loggedInUser={loggedInUser}>
            <p>Hello Moto</p>

            // </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
    </Routes>
  );
}
