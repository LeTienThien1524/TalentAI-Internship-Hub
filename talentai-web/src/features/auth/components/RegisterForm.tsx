import { useState, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";

import { register } from "../api/authApi";

function RegisterForm() {
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const [confirmPassword, setConfirmPassword] = useState("");

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      alert("Mật khẩu xác nhận không khớp");

      return;
    }

    try {
      const response = await register({
        email,
        password,
        confirmPassword,
      });

      if (response.isSuccess) {
        alert("Đăng ký thành công");

        navigate("/login");
      }
    } catch (error) {
      console.error(error);

      alert("Đăng ký thất bại");
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

      <div>
        <label>Confirm Password</label>

        <input
          type="password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
        />
      </div>

      <button type="submit">Register</button>
    </form>
  );
}

export default RegisterForm;
