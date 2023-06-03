import { Product } from "@models";

export interface CartItem {
  productId: string;
  amount: number;
}

export interface ProductInCart {
  product: Product;
  amount: number;
}
