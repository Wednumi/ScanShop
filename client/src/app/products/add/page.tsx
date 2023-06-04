import { addProduct, getCategories } from "@api";
import Edit from "@assets/edit.png";
import WhiteBg from "@assets/white-bg.png";

import Image from "next/image";
import Link from "next/link";

export default async function AddProduct() {
  const categories = await getCategories();

  return (
    <form action={addProduct} className="flex flex-col">
      <div className="flex gap-32">
        <Image
          src={WhiteBg}
          alt="Image"
          width={350}
          height={350}
          className="z-0"
        />
        <Image
          src={Edit}
          alt="Edit"
          width={50}
          height={50}
          className="z-10 absolute top-40 left-80 hover:link"
        />
        <div className="grid grid-cols-2 w-2/3 gap-24">
          <div className="flex flex-col">
            <input
              type="hidden"
              name="imageUrl"
              value={
                "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.publicdomainpictures.net%2Fpictures%2F150000%2Fvelka%2Fwhite-background-14532158163GC.jpg&f=1&nofb=1&ipt=e1d098f649b8fdcbc0942d839dd11c4a52e5759501aba07f163e9621911bb55f&ipo=images"
              }
            />
            <label htmlFor="title" className="font-semibold text-2xl">
              Назва
            </label>
            <input
              type="text"
              id="title"
              name="title"
              minLength={1}
              className="bg-brand-300 h-12 rounded-lg p-3"
            />
          </div>
          <div className="flex flex-col">
            <label htmlFor="amount" className="font-semibold text-2xl">
              Кількість (шт.)
            </label>
            <input
              type="number"
              id="amount"
              name="amount"
              className="bg-brand-300 h-12 rounded-lg p-3"
            />
          </div>
          <div className="flex flex-col">
            <label htmlFor="price" className="font-semibold text-2xl">
              Ціна (грн)
            </label>
            <input
              type="number"
              step={0.01}
              id="price"
              name="price"
              min={0}
              className="bg-brand-300 h-12 rounded-lg p-3"
            />
          </div>
          <div className="flex flex-col">
            <label htmlFor="discount" className="font-semibold text-2xl">
              Знижка (%)
            </label>
            <input
              type="number"
              id="discount"
              name="discount"
              min={0}
              max={100}
              className="bg-brand-300 h-12 rounded-lg p-3"
            />
          </div>
        </div>
      </div>
      <label htmlFor="categoryId" className="font-semibold text-2xl mt-12">
        Категорія
      </label>
      <select
        id="categoryId"
        name="categoryId"
        className="bg-brand-300 h-12 rounded-lg p-3"
      >
        {categories.map((c) => (
          <option key={c.id} value={c.id}>
            {c.title}
          </option>
        ))}
      </select>
      <label htmlFor="description" className="font-semibold text-2xl mt-12">
        Опис
      </label>
      <textarea
        id="description"
        name="description"
        minLength={1}
        className="bg-brand-300 h-32 rounded-lg p-3"
      />
      <div className="flex gap-20 self-end mt-12">
        <button className="btn btn-warning">Готово</button>
        <Link href="/" className="btn btn-error">
          Відмінити
        </Link>
      </div>
    </form>
  );
}
