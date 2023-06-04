import { getUserInfo } from "@api";
import { redirect } from "next/navigation";

export default async function Account() {
  const me = await getUserInfo();
  if (!me) redirect("/login");

  return (
    <div className="flex flex-col gap-6">
      <h1 className="font-bold text-3xl">Мій аккаунт</h1>
      <div className="flex flex-col gap-6 text-xl">
        <p>{`Ім'я: ${me.name}`}</p>
        <p>{`Прізвище: ${me.lastName}`}</p>
        <p>{`Електронна пошта: ${me.email}`}</p>
        <p>{`Бонуси: ${me.bonuses}`}</p>
        <p>{`Персональна знижка: ${(me.discount * 100).toFixed()}%`}</p>
      </div>
    </div>
  );
}
