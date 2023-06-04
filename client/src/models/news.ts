import { StaticImageData } from "next/image";

export interface NewsItem {
  id: string;
  image: StaticImageData;
  title: string;
  text: string;
  date: string;
}
