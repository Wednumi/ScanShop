import { cookies } from "next/headers";

export * from "./accounts";
export * from "./cart";
export * from "./categories";
export * from "./news";
export * from "./orders";
export * from "./products";
export * from "./users";

export const apiBaseUrl =
  process.env.NODE_ENV === "development"
    ? "https://localhost:7197/api"
    : "https://scanshop.azurewebsites.net/api";

export async function getToken() {
  return cookies().get("scan.shop.token")?.value;
}
