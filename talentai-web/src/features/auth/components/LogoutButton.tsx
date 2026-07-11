import { useNavigate } from "react-router-dom";

import { useAuth } from "../../../app/providers/AuthProvider";

function LogoutButton() {
  const navigate = useNavigate();

  const { logout } = useAuth();

  const handleLogout = () => {
    logout();

    navigate("/login");
  };

  return <button onClick={handleLogout}>Logout</button>;
}

export default LogoutButton;
