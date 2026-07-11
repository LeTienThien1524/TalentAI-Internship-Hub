export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  value: {
    userId: string;
    email: string;
    token: string;
    roles: string[];
  };

  isSuccess: boolean;
  isFailure: boolean;
  error: string;
}

export interface RegisterRequest {
  email: string;
  password: string;
  confirmPassword: string;
}
