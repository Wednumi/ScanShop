"use server";

import { apiBaseUrl, getToken } from "@api";
import { User } from "@models";

export async function getUserInfo(userId: string): Promise<User | null> {
  const token = await getToken();
  if (!token) {
    return null;
  }
  try {
    return await fetch(apiBaseUrl + "/User/info", {
      method: "POST",
      body: JSON.stringify({ userId }),
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      },
      cache: "no-store",
    }).then((r) => r.json());
  } catch (_) {
    return null;
  }
}
