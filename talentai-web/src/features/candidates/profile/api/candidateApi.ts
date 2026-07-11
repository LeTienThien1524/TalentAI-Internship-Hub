import axiosClient from "../../../../api/axiosClient";

export const getProfile = async () => {
  const response = await axiosClient.get("/api/candidates/profile");

  return response.data;
};

export const saveProfile = async (data: any) => {
  const response = await axiosClient.post("/api/candidates/profile", data);

  return response.data;
};
