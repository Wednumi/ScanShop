"use server";

import { getToken, apiBaseUrl, getProducts } from "@api";
import { CartItem, ProductInCart } from "@models";

export async function getCart(): Promise<ProductInCart[]> {
  const products = await getProducts();
  return await fetch(apiBaseUrl + "/Cart/get-cart", {
    cache: "no-store",
    headers: {
      Authorization: "Bearer " + (await getToken()),
    },
  })
    .then((r) => r.json())
    .then((c: CartItem[]) =>
      c.map((c) => {
        return {
          product: products.find((p) => p.id === c.productId)!,
          amount: c.amount,
        };
      })
    );
}

export async function addToCart(data: FormData) {
  const cartItem: CartItem = {
    productId: data.get("productId") as string,
    amount: 1,
  };
  fetch(apiBaseUrl + "/Cart/add-to-cart", {
    method: "POST",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
    cache: "no-store",
  });
  console.log(await getCart());
}

export async function updateProductInCart(data: FormData) {
  const cartItem: CartItem = {
    productId: data.get("productId") as string,
    amount: 1,
  };
  fetch(apiBaseUrl + "/Cart/update-amount", {
    method: "PUT",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
    cache: "no-store",
  });
}

export async function removeFromCart(data: FormData) {
  const cartItem: CartItem = {
    productId: data.get("productId") as string,
    amount: 1,
  };
  fetch(apiBaseUrl + "/Cart/remove", {
    method: "POST",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
    cache: "no-store",
  });
}
