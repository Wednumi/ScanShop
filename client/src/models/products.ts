export interface Product {
  id: string;
  title: string;
  price: number;
  discount: number;
  description: string;
  amount: number;
  imageUrl: string;
  categoryId: string;
  categoryName: string;
}

export interface CreateProduct {
  title: string;
  price: number;
  discount: number;
  description: string;
  amount: number;
  imageUrl: string;
  categoryId: string;
}
