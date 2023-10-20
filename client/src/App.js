import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Spinner } from "reactstrap";
import { tryGetLoggedInUser } from "./managers/authManager.js";
import { AuthorizedRoute } from "./components/auth/AuthorizedRoute.js";
import Login from "./components/auth/Login.js";
import Register from "./components/auth/Register.js";
import { Workspace } from "./components/Workspace.js";
import { Route, Routes } from "react-router-dom";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Workspace userId={loggedInUser.id} />
            </AuthorizedRoute>
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

export default App;
