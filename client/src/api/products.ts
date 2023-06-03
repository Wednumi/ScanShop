"use server";

import { apiBaseUrl, getToken } from "@api";
import { Product, CreateProduct } from "@models";

export async function getProducts(): Promise<Product[]> {
  return await fetch(apiBaseUrl + "/Product/all", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getProduct(id: string): Promise<Product | null> {
  return (await getProducts()).find((p: Product) => p.id === id) || null;
}

export async function addProduct(product: CreateProduct) {
  return fetch(apiBaseUrl + "/Product/update", {
    method: "POST",
    body: JSON.stringify(product),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
  });
}

export async function updateProduct(product: CreateProduct) {
  return fetch(apiBaseUrl + "/Product/update", {
    method: "POST",
    body: JSON.stringify(product),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
  });
}
