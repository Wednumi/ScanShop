import { getNews } from "@api";
import NewsItem from "@components/NewsItem";

export default async function News() {
  const news = await getNews();

  return (
    <div className="flex flex-col gap-8">
      <h1 className="font-semibold text-4xl">Новини</h1>
      <div className="grid grid-cols-3 gap-20">
        {news.map((item, index) => (
          <NewsItem key={index} news={item} />
        ))}
      </div>
    </div>
  );
}
