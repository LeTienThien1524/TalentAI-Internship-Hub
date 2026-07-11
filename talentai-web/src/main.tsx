import React from "react";
import ReactDOM from "react-dom/client";

import "./api/interceptor";

import App from "./App";

import { AuthProvider } from "./app/providers/AuthProvider";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <AuthProvider>
      <App />
    </AuthProvider>
  </React.StrictMode>,
);
