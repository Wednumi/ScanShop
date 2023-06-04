import { signIn } from "@api";
import Link from "next/link";

export default function Login() {
  return (
    <div className="bg-brand-100 rounded-lg p-6 w-96 mx-auto">
      <form action={signIn} className="flex flex-col">
        <label htmlFor="email">Електронна пошта</label>
        <input
          id="email"
          type="text"
          name="email"
          className="h-6 rounded p-2 w-full mb-6"
        />
        <label htmlFor="password">Пароль</label>
        <input
          id="password"
          type="password"
          name="password"
          className="h-6 rounded p-2 w-full mb-6"
        />
        <button type="submit" className="btn btn-primary">
          Увійти
        </button>
        <h2 className="text-center font-semibold text-xl mt-6">
          <span>Немає запису? </span>
          <Link href="/signup" className="hover:text-brand-500">
            <span>Зареєструватися</span>
          </Link>
        </h2>
      </form>
    </div>
  );
}
