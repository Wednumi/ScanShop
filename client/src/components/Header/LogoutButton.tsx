import { signOut } from "@api";
import Logout from "@assets/logout.png";

import Image from "next/image";

export default function LogoutButton() {
  return (
    <form action={signOut}>
      <button type="submit" className="w-auto flex gap-3 items-center p-3">
        <Image width={35} height={35} src={Logout} alt="Logout" />
        <p className="text-lg">Вийти з запису</p>
      </button>
    </form>
  );
}
