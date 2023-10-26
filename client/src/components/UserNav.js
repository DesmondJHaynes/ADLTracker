import { Button, Navbar } from "reactstrap";
import { logout } from "../managers/authManager.js";

export const UserNav = ({ user, setLoggedInUser }) => {
  return (
    <Navbar>
      {user.roles[0]} : {user.lastName}, {user.firstName[0]}.
      <Button
        color="danger"
        onClick={(e) => {
          e.stopPropagation();
          logout().then(() => {
            setLoggedInUser(null);
          });
        }}
      >
        Logout
      </Button>
    </Navbar>
  );
};
