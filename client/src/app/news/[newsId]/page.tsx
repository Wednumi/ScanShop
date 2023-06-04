import { getNews } from "@api";
import { NewsItem } from "@models";
import NewsItemComponent from "@components/NewsItem";

import Image from "next/image";
import Link from "next/link";
import { notFound } from "next/navigation";

type Props = {
  params: {
    newsId: string;
  };
};

export default async function NewsExpanded({ params: props }: Props) {
  const allNews = await getNews();
  const item = allNews.find((n: NewsItem) => n.id === props.newsId);
  if (!item) return notFound();

  const otherNews = allNews.filter((n: NewsItem) => n.id !== props.newsId);

  return (
    <div className="flex gap-20">
      <div className="flex flex-col w-2/3">
        <Link
          href="/news"
          className="text-lg hover:link hover:text-brand-500"
          style={{ marginTop: -30, marginBottom: 30 }}
        >
          {"<- Усі новини"}
        </Link>
        <div className="flex flex-col gap-4">
          <h1 className="text-4xl font-semibold">{item?.title}</h1>
          <span className="text-lg text-gray-600">{item.date}</span>
          <div className="flex justify-between">
            <Image src={item.image} alt={item.title} className="w-full" />
          </div>
          <p className="text-lg">{item.text}</p>
        </div>
      </div>
      <div className="w-1/3 flex flex-col gap-6">
        <h3 className="font-semibold text-xl">Інші новини</h3>
        <div className="flex flex-col gap-16">
          {otherNews.map((n: NewsItem) => (
            <NewsItemComponent key={n.id} news={n} />
          ))}
        </div>
      </div>
    </div>
  );
}
