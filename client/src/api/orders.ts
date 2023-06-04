"use server";

import { apiBaseUrl, getToken } from "@api";
import { Order } from "@models";

export async function getOrders(): Promise<Order[]> {
  const token = await getToken();
  if (!token) {
    return [];
  }
  return await fetch(apiBaseUrl + "/Order/all", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getPendingOrders(): Promise<Order[]> {
  const token = await getToken();
  if (!token) {
    return [];
  }
  return await fetch(apiBaseUrl + "/Order/all-without-checkout", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getUserOrders(): Promise<Order[]> {
  const token = await getToken();
  if (!token) {
    return [];
  }
  return await fetch(apiBaseUrl + "/Order/user-orders", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getOrder(): Promise<Order | null> {
  const token = await getToken();
  if (!token) {
    return null;
  }
  try {
    return await fetch(apiBaseUrl + "/Order/by-id", {
      cache: "no-store",
    }).then((r) => r.json());
  } catch (_) {
    return null;
  }
}

export async function makeOrder() {
  const token = await getToken();
  if (!token) {
    return;
  }
  await fetch(apiBaseUrl + "/Order/create-from-cart", {
    method: "POST",
    headers: {
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  });
}
