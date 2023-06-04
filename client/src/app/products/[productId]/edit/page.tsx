import { getProduct, updateProduct } from "@api";
import Edit from "@assets/edit.png";

import Image from "next/image";
import Link from "next/link";

type Props = {
  params: {
    productId: string;
  };
};

export default async function EditProduct({ params }: Props) {
  const product = await getProduct(params.productId);

  return (
    <form action={updateProduct} className="flex flex-col">
      <div className="flex gap-32">
        <Image
          src={product.imageUrl}
          alt={product.title}
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
            <input type="hidden" name="id" value={product.id} />
            <input type="hidden" name="categoryId" value={product.categoryId} />
            <input type="hidden" name="imageUrl" value={product.imageUrl} />
            <input
              type="hidden"
              name="categoryName"
              value={product.categoryName}
            />
            <label htmlFor="title" className="font-semibold text-2xl">
              Назва
            </label>
            <input
              type="text"
              id="title"
              name="title"
              defaultValue={product.title}
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
              defaultValue={product.amount}
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
              defaultValue={product.price}
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
              defaultValue={Math.round(product.discount * 100)}
              min={0}
              max={100}
              className="bg-brand-300 h-12 rounded-lg p-3"
            />
          </div>
        </div>
      </div>
      <label htmlFor="description" className="font-semibold text-2xl mt-12">
        Опис
      </label>
      <textarea
        id="description"
        name="description"
        defaultValue={product.description}
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
