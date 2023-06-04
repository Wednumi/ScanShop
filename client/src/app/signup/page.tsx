import { signUp } from "@api";

export default function Login() {
  return (
    <div className="bg-brand-100 rounded p-6 w-96 mx-auto">
      <form action={signUp} className="flex flex-col">
        <label htmlFor="email">Електронна пошта</label>
        <input
          id="email"
          type="text"
          name="email"
          className="h-8 rounded p-2 w-full mb-6"
          minLength={1}
        />
        <label htmlFor="name">{"Ім'я"}</label>
        <input
          id="name"
          type="text"
          name="name"
          className="h-8 rounded p-2 w-full mb-6"
          minLength={1}
        />
        <label htmlFor="lastName">Фамілія</label>
        <input
          id="lastName"
          type="text"
          name="lastName"
          className="h-8 rounded p-2 w-full mb-6"
          minLength={1}
        />
        <label htmlFor="password">Пароль</label>
        <input
          id="password"
          type="password"
          name="password"
          className="h-8 rounded p-2 w-full mb-6"
          minLength={8}
        />
        <label htmlFor="confirmPassword">Повторіть пароль</label>
        <input
          id="confirmPassword"
          type="password"
          name="confirmPassword"
          className="h-8 rounded p-2 w-full mb-6"
          minLength={8}
        />
        <button type="submit" className="btn btn-primary">
          Зареєструватися
        </button>
      </form>
    </div>
  );
}
