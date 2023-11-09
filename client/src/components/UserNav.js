import { Button, Navbar } from "reactstrap";
import { logout } from "../managers/authManager.js";

export const UserNav = ({ user, setLoggedInUser }) => {
  return (
    <Navbar>
      <div className="user-title">
        {user.lastName}, {user.firstName[0]}. | {user.roles[0]}
      </div>
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
