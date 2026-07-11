export function getUser() {
  const user = localStorage.getItem("user");

  if (!user) {
    return null;
  }

  return JSON.parse(user);
}

export function getRoles() {
  const user = getUser();

  return user?.roles ?? [];
}
