import { Navigate } from "react-router-dom";

import { getRoles } from "../../shared/utils/auth";

interface Props {
  children: React.ReactNode;
  allowedRoles: string[];
}

function RoleRoute({ children, allowedRoles }: Props) {
  const roles = getRoles();

  const hasRole = allowedRoles.some((role) => roles.includes(role));

  if (!hasRole) {
    return <Navigate to="/forbidden" replace />;
  }

  return <>{children}</>;
}

export default RoleRoute;
