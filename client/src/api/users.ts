"use server";

import { apiBaseUrl, getToken } from "@api";
import { User } from "@models";

export async function getUserInfo(userId: string): Promise<User | null> {
  try {
    return await fetch(apiBaseUrl + "/User/info", {
      method: "POST",
      body: JSON.stringify({ userId }),
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + (await getToken()),
      },
      cache: "no-store",
    }).then((r) => r.json());
  } catch (_) {
    return null;
  }
}
