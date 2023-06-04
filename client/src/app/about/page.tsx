import Logo from "@assets/logogo.png";
import Clock from "@assets/clock.png";
import Home from "@assets/home.png";

import Image from "next/image";

export default function About() {
  return (
    <div className="flex flex-col h-full">
      <h1 className="text-4xl font-semibold">
        {'Сервіс замовлення товарів в "Scan&Shop"'}
      </h1>
      <div className="flex gap-8">
        <div className="flex flex-col w-2/3 gap-8 mt-12">
          <div className="bg-brand-200 rounded-md flex gap-8 p-6">
            <Image src={Home} alt="Home" width={400} height={400} />
            <p className="text-3xl">
              Відтепер, сидячи вдома з улюбленим гаджетом в руках, ви зможете
              відвідати Scan&Shop та заздалегідь замовити майже все необхідне!
            </p>
          </div>
          <div className="bg-brand-200 rounded-md flex gap-8 p-6 pl-10">
            <Image
              src={Clock}
              alt="Time"
              width={400}
              height={400}
              className="mr-5"
            />
            <p className="text-3xl">
              І найголовніше, вам не потрібно витрачати час на відвідування
              магазину і пошук потрібних товарів - на момент відвідування
              магазину, ваше замовлення вже чекатиме на вас!
            </p>
          </div>
        </div>
        <Image src={Logo} alt="Logo" width={500} height={500} />
      </div>
    </div>
  );
}
