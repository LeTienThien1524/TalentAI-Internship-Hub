import { useEffect } from "react";

import { getProfile } from "../api/candidateApi";

function CandidateProfilePage() {
  useEffect(() => {
    loadProfile();
  }, []);

  const loadProfile = async () => {
    try {
      const response = await getProfile();

      console.log(response);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <h1>Candidate Profile</h1>
    </div>
  );
}

export default CandidateProfilePage;
