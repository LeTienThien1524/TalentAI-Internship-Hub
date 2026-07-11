export interface CandidateProfile {
  firstName: string;
  lastName: string;
  dateOfBirth?: string;
  university: string;
  major: string;
  gpa?: number;
  provinceId?: number;
  avatarUrl?: string;
}

export interface CandidateProfileResponse {
  value: CandidateProfile;
  isSuccess: boolean;
  isFailure: boolean;
  error: string;
}
