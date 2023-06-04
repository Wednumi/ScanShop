"use server";

import { getToken, apiBaseUrl, getProducts } from "@api";
import { CartItem, ProductInCart } from "@models";

export async function getCart(): Promise<ProductInCart[]> {
  const token = await getToken();
  if (!token) {
    return [];
  }
  const products = await getProducts();
  const res = await fetch(apiBaseUrl + "/Cart/get-cart", {
    cache: "no-store",
    headers: {
      Authorization: "Bearer " + token,
    },
  });
  let json;
  try {
    json = await res.json();
  } catch (_) {
    return [];
  }
  const cartItems = json.map((c: CartItem) => {
    return {
      product: products.find((p) => p.id === c.productId)!,
      amount: c.amount,
    };
  });
  return cartItems;
}

export async function addToCart(data: FormData) {
  const token = await getToken();
  if (!token) {
    return;
  }
  const cartItem: CartItem = {
    productId: data.get("productId") as string,
    amount: 1,
  };
  await fetch(apiBaseUrl + "/Cart/add-to-cart", {
    method: "POST",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  });
}

export async function updateProductInCart(data: FormData) {
  const token = await getToken();
  if (!token) {
    return;
  }
  const cartItem: CartItem = {
    productId: data.get("productId") as string,
    amount: 1,
  };
  await fetch(apiBaseUrl + "/Cart/update-amount", {
    method: "PUT",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  });
}

export async function removeFromCart(data: FormData) {
  const token = await getToken();
  if (!token) {
    return;
  }
  const cartItem: CartItem = {
    productId: data.get("productId") as string,
    amount: 1,
  };
  await fetch(apiBaseUrl + "/Cart/remove", {
    method: "POST",
    body: JSON.stringify(cartItem),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  });
}
