import { cookies } from "next/headers";

export * from "./accounts";
export * from "./cart";
export * from "./categories";
export * from "./orders";
export * from "./products";
export * from "./users";

export const apiBaseUrl = "https://localhost:7197/api";

export async function getToken() {
  return cookies().get("scan.shop.token")?.value;
}
