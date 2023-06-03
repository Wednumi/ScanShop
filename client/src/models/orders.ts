import { CartItem } from "@models";

export interface Order {
  id: string;
  userId: string;
  customerFullName: string;
  orderItems: CartItem[];
  packedTime: string;
  createdTime: string;
  paidTime: string;
  checkoutTime: string;
}
