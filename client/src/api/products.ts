"use server";

let products = [
  {
    id: "1",
    title: "Пельмені 0,8 кг Левада Фірмові з яловичиною",
    price: 122.2,
    discount: 0.13,
    description:
      "Фарш 50% (м'ясна сировина - 65% (м'ясо яловичини знежиловане - 50%, м'ясо куряче обвалене), цибуля ріпчаста свіжа, вода питна, молоко сухе незбиране, сіль кухонна, прянощі, мускатний горіх мелений, натуральні антиоксиданти: екстракт розмарину, екстракт зеленого чаю, ароматизатор), тісто 50% (борошно пшеничне вищого сорту, вода питна, олія соняшникова рафінована дезодорована, сіль кухонна, яєчний порошок, ферменти хлібопекарські)",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/7259/catalog_product_gal_7259.jpg",
  },
  {
    id: "2",
    title: "Огірки 870 г Malpol  мариновані ",
    price: 119.99,
    discount: 0.28,
    description: "",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/31497/catalog_product_gal_31497.jpg",
  },
  {
    id: "3",
    title: "Печиво 225 г Belvita мультизлакове",
    price: 74.99,
    discount: 0.31,
    description:
      "Злаки 68.9% (борошно пшеничне 48.9%, злаки цільнозернові 20% (борошно пшеничне цільнозернове 6.4%, крупка вівсяна 4.5%, пластівці вівсяні 3.1%, борошно з ячменю цільнозернове 2.9%, борошно житнє цільнозернове 2.1%, борошно із пшениці цільнозернове 1%), цукор, олія ріпакова, наповнювач (полідекстроза), розпушувачі (гідрокарбонат натрію, гідрокарбонат амонію, пірофосфат натрію), мінеральні речовини (карбонат кальцію, карбонат магнію, залізо), молоко сухе незбиране 0.9%, емульгатори (лецитин соєвий, Е472е), сіль кухонна, молоко сухе знежирене",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/33039/catalog_product_gal_33039.jpg",
  },
  {
    id: "4",
    title: "Пивo 0,9 л Чepнігівськe Білe",
    price: 39.99,
    discount: 0.18,
    description: "",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/33313/catalog_product_gal_33313.jpg",
  },
  {
    id: "5",
    title: "Стегно курчат-бройлерів Чебатурочка",
    price: 90.99,
    discount: 0,
    description: "",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/11971/catalog_product_gal_11971.jpg",
  },
  {
    id: "6",
    title: "Кава 120г Чорна Карта Gold",
    price: 107.99,
    discount: 0,
    description: "Кава натуральна розчинна сублімована",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/5995/catalog_product_gal_5995.jpg",
  },
  {
    id: "7",
    title: "Сир плавлений 70 г Золотий Резерв Вершковий 50 %",
    price: 15.3,
    discount: 0,
    description: "",
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/15963/catalog_product_gal_15963.jpg",
  },
  {
    id: "8",
    title: "Морозиво 0,5 кг Ласка Кенійська Зебра",
    price: 85.4,
    discount: 0,
    description:
      'Морозиво (молоко коров\'яче незбиране, цукор, олія кокосова рафінована вибілена дезодорована, вода питна, молоко сухе знежирене, какао-порошок зі зниженим вмістом жиру 1.5%, суміш стабілізаторів і емульгаторів, ароматизатор "Ванілін"), молоко згущене з цукром 8.9% (молоко коров\'яче незбиране, цукор, цукор молочний), наповнювач ароматичний "Карамельний соус" 8.9% (молоко незбиране згущене з цукром, цукор, крохмаль модифікований кукурудзяний, ароматизатор "Карамель")',
    amount: 69420,
    imageUrl:
      "https://src.zakaz.atbmarket.com/cache/photos/7506/catalog_product_gal_7506.jpg",
  },
];

export async function getProducts() {
  return products;
}
