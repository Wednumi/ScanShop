"use server";

import { getToken, apiBaseUrl, getProducts } from "@api";
import { CartItem, Product } from "@models";

export async function getCart(): Promise<[Product, number][]> {
  const products = await getProducts();
  return await fetch(apiBaseUrl + "/Cart/get-cart", {
    cache: "no-store",
  })
    .then((r) => r.json())
    .then((p: CartItem[]) =>
      p.map((c) => [products.find((p) => p.id === c.productId)!, c.amount])
    );
}

export async function addToCart(cartItem: CartItem) {
  return fetch(apiBaseUrl + "/Cart/add-to-cart", {
    method: "POST",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
  });
}

export async function updateProductInCart(cartItem: CartItem) {
  return fetch(apiBaseUrl + "/Cart/update-amount", {
    method: "PUT",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
  });
}

export async function removeFromCart(cartItem: CartItem) {
  return fetch(apiBaseUrl + "/Cart/remove", {
    method: "POST",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
  });
}
