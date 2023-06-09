"use server";

import { apiBaseUrl, getToken } from "@api";
import { Product, CreateProduct } from "@models";

import { notFound } from "next/navigation";

export async function getProducts(): Promise<Product[]> {
  return await fetch(apiBaseUrl + "/Product/all", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getProductsInCategory(
  categoryId: string
): Promise<Product[]> {
  return (await getProducts()).filter(
    (p: Product) => p.categoryId === categoryId
  );
}

export async function getDiscountedProducts(): Promise<Product[]> {
  return (await getProducts()).filter((p: Product) => p.discount > 0);
}

export async function getProduct(id: string): Promise<Product> {
  const product = (await getProducts()).find((p: Product) => p.id === id);
  if (!product) {
    notFound();
  }
  return product;
}

export async function addProduct(data: FormData) {
  const token = await getToken();
  if (!token) {
    return;
  }
  const product: CreateProduct = {
    title: data.get("title") as string,
    price: Number(data.get("price")),
    discount: Number(data.get("discount")) / 100,
    amount: Number(data.get("amount")),
    description: data.get("description") as string,
    categoryId: data.get("categoryId") as string,
    imageUrl: data.get("imageUrl") as string,
  };
  await fetch(apiBaseUrl + "/Product/update", {
    method: "POST",
    body: JSON.stringify(product),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  });
}

export async function updateProduct(data: FormData) {
  const token = await getToken();
  if (!token) {
    return;
  }
  const product: Product = {
    id: data.get("id") as string,
    title: data.get("title") as string,
    price: Number(data.get("price")),
    discount: Number(data.get("discount")) / 100,
    amount: Number(data.get("amount")),
    description: data.get("description") as string,
    categoryId: data.get("categoryId") as string,
    imageUrl: data.get("imageUrl") as string,
    categoryName: data.get("categoryName") as string,
  };
  await fetch(apiBaseUrl + "/Product/update", {
    method: "POST",
    body: JSON.stringify(product),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    cache: "no-store",
  });
}
