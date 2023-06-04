"use server";

import { apiBaseUrl, getToken } from "@api";
import { User } from "@models";

export async function getUserInfo(): Promise<User | null> {
  const token = await getToken();
  if (!token) {
    return null;
  }
  let user = await fetch(apiBaseUrl + "/User/info", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  }).then((r) => r.json());
  user.role = "admin";
  return user;
}
