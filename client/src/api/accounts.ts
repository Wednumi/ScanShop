"use server";

import { apiBaseUrl } from "@api";
import { SignUp, SignIn } from "@models";

export async function signUp(data: FormData) {
  const credentials: SignUp = {
    email: data.get("email") as string,
    name: data.get("name") as string,
    lastName: data.get("lastName") as string,
    password: data.get("password") as string,
    confirmPassword: data.get("confirmPassword") as string,
  };
  fetch(apiBaseUrl + "/Account/sign-up", {
    method: "POST",
    body: JSON.stringify(credentials),
    headers: {
      "Content-Type": "application/json",
    },
    cache: "no-store",
  });
}

export async function signIn(data: FormData) {
  const credentials: SignIn = {
    email: data.get("email") as string,
    password: data.get("password") as string,
  };
  fetch(apiBaseUrl + "/Account/sign-in", {
    method: "POST",
    body: JSON.stringify(credentials),
    headers: {
      "Content-Type": "application/json",
    },
    cache: "no-store",
  });
}
