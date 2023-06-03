"use server";

import { apiBaseUrl } from "@api";
import { SignUp, SignIn } from "@models";

export async function signUp(credentials: SignUp) {
  return fetch(apiBaseUrl + "/Account/sign-up", {
    method: "POST",
    body: JSON.stringify(credentials),
    headers: {
      "Content-Type": "application/json",
    },
  });
}

export async function signIn(credentials: SignIn) {
  return fetch(apiBaseUrl + "/Account/sign-in", {
    method: "POST",
    body: JSON.stringify(credentials),
    headers: {
      "Content-Type": "application/json",
    },
  });
}
