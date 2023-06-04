import { addToCart } from "@api";
import { Product } from "@models";
import CartIcon from "@assets/cart.png";

import Image from "next/image";

type Props = {
  product: Product;
};

export default function AddProductToCart({ product }: Props) {
  return (
    <form action={addToCart}>
      <input type="hidden" name="productId" value={product.id} />
      <button
        type="submit"
        className="justify-end btn btn-primary w-12 p-1 pt-2 mt-4 mr-1"
      >
        <Image src={CartIcon} alt="Add to cart" width={47} />
      </button>
    </form>
  );
}
