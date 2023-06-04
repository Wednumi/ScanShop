"use server";

import { apiBaseUrl } from "@api";
import { SignUp, SignIn } from "@models";

import { redirect } from "next/navigation";
import { cookies } from "next/headers";

export async function signUp(data: FormData) {
  const credentials: SignUp = {
    email: data.get("email") as string,
    name: data.get("name") as string,
    lastName: data.get("lastName") as string,
    password: data.get("password") as string,
    confirmPassword: data.get("confirmPassword") as string,
  };
  await fetch(apiBaseUrl + "/Account/sign-up", {
    method: "POST",
    body: JSON.stringify(credentials),
    headers: {
      "Content-Type": "application/json",
    },
    cache: "no-store",
  });
  redirect("/login");
}

export async function signIn(data: FormData) {
  const credentials: SignIn = {
    email: data.get("email") as string,
    password: data.get("password") as string,
  };
  const token = await fetch(apiBaseUrl + "/Account/sign-in", {
    method: "POST",
    body: JSON.stringify(credentials),
    headers: {
      "Content-Type": "application/json",
    },
    cache: "no-store",
  }).then((r) => r.text());

  if (token.indexOf("{") !== -1) {
    return;
  }

  // @ts-ignore
  cookies().set("scan.shop.token", token);
  redirect("/");
}

export async function signOut() {
  // @ts-ignore
  cookies().set("scan.shop.token", "");
}
