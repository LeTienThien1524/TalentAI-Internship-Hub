import { useState, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";

import { login } from "../api/authApi";
import { useAuth } from "../../../app/providers/AuthProvider";

function LoginForm() {
  const navigate = useNavigate();

  const { login: saveToken } = useAuth();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      const response = await login({
        email,
        password,
      });

      if (response.isSuccess) {
        localStorage.setItem("user", JSON.stringify(response.value));

        saveToken(response.value.token);

        navigate("/candidate/profile");
      }
    } catch (error) {
      console.error(error);

      alert("Đăng nhập thất bại");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Email</label>

        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>

      <div>
        <label>Password</label>

        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>

      <button type="submit">Login</button>
    </form>
  );
}

export default LoginForm;
