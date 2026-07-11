import axiosClient from "../../../api/axiosClient";
import endpoints from "../../../api/endpoints";

import type {
  LoginRequest,
  LoginResponse,
  RegisterRequest,
} from "../types/auth.types";

export const login = async (data: LoginRequest): Promise<LoginResponse> => {
  const response = await axiosClient.post(endpoints.auth.login, data);

  return response.data;
};

export const register = async (
  data: RegisterRequest,
): Promise<LoginResponse> => {
  const response = await axiosClient.post(endpoints.auth.register, data);

  return response.data;
};
