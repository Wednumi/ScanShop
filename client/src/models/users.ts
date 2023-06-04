export interface User {
  email: string;
  discount: number;
  bonuses: number;
  name: string;
  lastName: string;
  role: "user" | "admin";
}
