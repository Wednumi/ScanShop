"use client";

type Props = {
  setShow: React.Dispatch<React.SetStateAction<boolean>>;
};

export default function CartModal({ setShow }: Props) {
  return (
    <div
      className="fixed top-0 left-0 w-screen h-screen flex justify-center items-center bg-gray-600 bg-opacity-50 z-10"
      onClick={() => setShow(false)}
    >
      <div
        className="w-96 h-auto rounded-lg bg-white z-20 flex flex-col gap-4 items-center"
        onClick={(e) => e.stopPropagation()}
      >
        <div className="w-full py-4 rounded-t-lg bg-brand-500 text-center align-middle">
          <p className="text-2xl text-white">Кошик</p>
        </div>
        <div className="w-full max-h-80 overflow-auto flex flex-col justify-center">
          <div className="w-full h-20 flex">
            <div className="basis-1/4 text-center">Пикча</div>
            <div className="basis-1/2 text-center">Название</div>
            <div className="basis-1/4 text-center">Кол-во</div>
          </div>
        </div>
        <p className="text-md">Загальна вартість: 999999 грн</p>
        <button
          className="w-1/2 text-white text-xl font-bold bg-yellow-600 p-3 mb-3 rounded-md"
          onClick={() => setShow(false)}
        >
          Замовити
        </button>
      </div>
    </div>
  );
}
