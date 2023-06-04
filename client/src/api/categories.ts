"use server";

import { apiBaseUrl, getToken } from "@api";
import { Category, CreateCategory } from "@models";

export async function getCategories(): Promise<Category[]> {
  return await fetch(apiBaseUrl + "/Category/all", {
    cache: "no-store",
  }).then((r) => r.json());
}

export async function getCategory(id: string): Promise<Category | null> {
  return (await getCategories()).find((p: Category) => p.id === id) || null;
}

export async function addCategory(data: FormData) {
  const category: CreateCategory = {
    title: data.get("title") as string,
  };
  fetch(apiBaseUrl + "/Category/update", {
    method: "POST",
    body: JSON.stringify(category),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
  });
}

export async function updateCategory(data: FormData) {
  const category: Category = {
    id: data.get("id") as string,
    title: data.get("title") as string,
  };
  fetch(apiBaseUrl + "/Category/update", {
    method: "POST",
    body: JSON.stringify(category),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + (await getToken()),
    },
  });
}

export async function removeCategory(data: FormData) {
  const categoryId: string = data.get("categoryId") as string;
  fetch(apiBaseUrl + `/Category/delete?id=${categoryId}`, {
    method: "POST",
    headers: {
      Authorization: "Bearer " + (await getToken()),
    },
  });
}
