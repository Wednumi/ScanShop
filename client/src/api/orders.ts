"use server";

import { apiBaseUrl, getToken } from "@api";
import { Order } from "@models";

export async function getOrders(): Promise<Order[]> {
  return await fetch(apiBaseUrl + "/Order/all", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getPendingOrders(): Promise<Order[]> {
  return await fetch(apiBaseUrl + "/Order/all-without-checkout", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getUserOrders(): Promise<Order[]> {
  return await fetch(apiBaseUrl + "/Order/user-orders", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getOrder(): Promise<Order | null> {
  try {
    return await fetch(apiBaseUrl + "/Order/by-id", {
      cache: "no-store",
    }).then((r) => r.json());
  } catch (_) {
    return null;
  }
}

export async function makeOrder() {
  return fetch(apiBaseUrl + "/Order/create-from-cart", {
    method: "POST",
    headers: {
      Authorization: "Bearer " + (await getToken()),
    },
  });
}
