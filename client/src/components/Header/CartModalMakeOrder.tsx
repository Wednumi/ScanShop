import { makeOrder } from "@api";

export default function CartModalMakeOrder() {
  return (
    <form
      action={makeOrder}
      className="w-1/2 text-white text-xl font-bold mb-3"
    >
      <button type="submit" className="w-full btn btn-warning">
        Замовити
      </button>
    </form>
  );
}
