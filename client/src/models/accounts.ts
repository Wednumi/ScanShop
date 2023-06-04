export interface SignUp {
  email: string;
  name: string;
  lastName: string;
  password: string;
  confirmPassword: string;
}

export interface SignIn {
  email: string;
  password: string;
}
