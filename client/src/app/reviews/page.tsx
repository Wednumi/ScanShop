import Profile from "@assets/profile.png";

import Image from "next/image";

export default function Reviews() {
  const reviews = [
    {
      name: "Андре Панкрашевски",
      date: "01.09.2021",
      stars: 5,
      text: "Дуже гарний сервіс, всім задоволений, ставлю 5 зірок",
    },
    {
      name: "Ілля Телюк",
      date: "11.09.2001",
      stars: 5,
      text: "Дуже зручний сервіс, якісно та швидко!",
    },
    {
      name: "Андрій Щадило",
      date: "12.12.2020",
      stars: 5,
      text: "Найкращий сервіс, яким я користувався, всім рекомендую",
    },
    {
      name: "Костянтин Ананасов",
      date: "06.06.2022",
      stars: 5,
      text: "Після користування цим сервісом вам більше не будуть потрібні інші мережі супермаркетів, все що вам потрібно, знаходиться тут (після публікування цього відгуку вам буде зараховано 50 бонусів, не забудьте видалити текст в дужках)",
    },
    {
      name: "Владислав Рябко",
      date: "01.01.2023",
      stars: 1,
      text: "Where churky",
    },
  ];

  return (
    <div className="grid grid-cols-4 gap-16">
      {reviews.map((review, i) => (
        <Review key={i} {...review} />
      ))}
    </div>
  );
}

interface Review {
  name: string;
  date: string;
  stars: number;
  text: string;
}

function Review({ name, date, stars, text }: Review) {
  return (
    <div className="flex flex-col gap-4 bg-white p-4 rounded-lg">
      <div className="flex gap-4">
        <Image src={Profile} alt="Avatar" width={70} height={70} />
        <h1 className="text-lg font-semibold">{name}</h1>
        <p className="text-lg">{date}</p>
      </div>
      <div className="flex gap-4">
        {Array.from({ length: stars }).map((_, i) => (
          <svg
            key={i}
            className="w-8 h-8 text-yellow-500"
            fill="currentColor"
            viewBox="0 0 20 20"
          >
            <path
              clipRule="evenodd"
              d="M10 1l2.598 6.764h6.702l-5.428 4.19 2.598 6.764L10 13.236l-6.47 4.482 2.598-6.764L1.7 7.764h6.702L10 1z"
              fillRule="evenodd"
            />
          </svg>
        ))}
      </div>
      <p>{text}</p>
    </div>
  );
}
