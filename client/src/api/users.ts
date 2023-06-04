"use server";

import { apiBaseUrl, getToken } from "@api";
import { User } from "@models";

export async function getUserInfo(): Promise<User | null> {
  const token = await getToken();
  if (!token) {
    return null;
  }
  return await fetch(apiBaseUrl + "/User/info", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  }).then((r) => r.json());
}
