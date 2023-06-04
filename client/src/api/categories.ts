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
  const token = await getToken();
  if (!token) {
    return;
  }
  const category: CreateCategory = {
    title: data.get("title") as string,
  };
  await fetch(apiBaseUrl + "/Category/update", {
    method: "POST",
    body: JSON.stringify(category),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
  });
}

export async function updateCategory(data: FormData) {
  const token = await getToken();
  if (!token) {
    return;
  }
  const category: Category = {
    id: data.get("id") as string,
    title: data.get("title") as string,
  };
  await fetch(apiBaseUrl + "/Category/update", {
    method: "POST",
    body: JSON.stringify(category),
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
  });
}

export async function removeCategory(data: FormData) {
  const token = await getToken();
  if (!token) {
    return;
  }
  const categoryId: string = data.get("categoryId") as string;
  await fetch(apiBaseUrl + `/Category/delete?id=${categoryId}`, {
    method: "POST",
    headers: {
      Authorization: "Bearer " + token,
    },
  });
}
