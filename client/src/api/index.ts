export * from "./accounts";
export * from "./cart";
export * from "./categories";
export * from "./orders";
export * from "./products";
export * from "./users";

export const apiBaseUrl = "https://localhost:7197/api";

export async function getToken() {
  return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlckBleGFtcGxlLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNmZjZmE1MzEtZmU5YS00YjViLWFjYjItYjRlNDU3OGZjZjZiIiwibmJmIjoiMTY4NTc5NTc2NCIsImV4cCI6IjE2ODgzODc3NjQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiJ9.am5qfeCoX5xRLOwrTlCFhrjcMcLJoc8AwXeYGcxgpCo";
}
