import { NewsItem } from "@models";

import Image from "next/image";
import Link from "next/link";

type Props = {
  news: NewsItem;
};

export default function NewsItem({ news }: Props) {
  const maxDescriptionLength = 90;

  return (
    <Link href={`news/${news.id}`} className="card bg-white">
      <Image
        src={news.image}
        alt={news.title}
        className="w-full rounded-t-2xl"
      />
      <div className="p-5 flex flex-col gap-6">
        <div>
          <h1 className="font-semibold text-xl">{news.title}</h1>
          <p>
            {news.text.slice(0, maxDescriptionLength) +
              (news.text.length > maxDescriptionLength ? "..." : "")}
          </p>
        </div>
        <div className="flex justify-between">
          <span>{news.date}</span>
          <span className="font-semibold">Читати повністю</span>
        </div>
      </div>
    </Link>
  );
}
