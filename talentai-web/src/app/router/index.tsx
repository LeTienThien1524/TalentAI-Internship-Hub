import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "../../pages/HomePage";
import NotFoundPage from "../../pages/NotFoundPage";

import LoginPage from "../../features/auth/pages/LoginPage";
import RegisterPage from "../../features/auth/pages/RegisterPage";

import ProtectedRoute from "./ProtectedRoute";

import CandidateProfilePage from "../../features/candidates/profile/pages/CandidateProfilePage";
import RoleRoute from "./RoleRoute";

function AppRouter() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />

        <Route path="/login" element={<LoginPage />} />

        <Route path="/register" element={<RegisterPage />} />

        <Route
          path="/candidate/profile"
          element={
            <ProtectedRoute>
              <RoleRoute allowedRoles={["Candidate"]}>
                <CandidateProfilePage />
              </RoleRoute>
            </ProtectedRoute>
          }
        />

        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default AppRouter;
