INSERT INTO categories(category_id, name)
VALUES("d7f5c843-8d5c-4bc6-804a-6c80741c787d", "آرایشی و بهداشتی"),
("0b15276b-e6c6-4b6b-a538-f2d045e9bd5b", "پوشاک"),
("2ba33d6e-fc05-40da-b28e-3a9197e41955", "دیجیتال"),
("4d60246a-3455-45b9-b58c-7d7bc9ddddb5", "مواد غذایی"),
("3263d16b-e318-4885-959f-5f4f1fcef4c5", "ابزار و تجهیزات صنعتی"),
("189634d3-72f8-4394-b4ac-451931bd32bf", "خانگی"),
("f1e6a736-d09a-4c34-ac8b-1bb6824de3ce", "متفرقه");

INSERT INTO products(productId, name, categoryId, stock, 
submissionDate, unit, price)
VALUES("2e9efb38-32d5-45b7-8101-55a1021882dc", "میز ناهارخوری ناصر پلاستیک مدل 323", 
"189634d3-72f8-4394-b4ac-451931bd32bf", 35, date(), "عدد", 2080000),
("c469e8ec-5796-4776-a4f9-b100a3243b1d", "شلوار مردانه پنبه شکار مدل اسلش شش جیب",
"0b15276b-e6c6-4b6b-a538-f2d045e9bd5b", 12, date(), "عدد", 100400),
("c9579fda-bf49-42e2-9056-9a3e2367b484", "خامه ترش کاله - 200 گرم",
"4d60246a-3455-45b9-b58c-7d7bc9ddddb5", 101, date(), "گرم", 25000),
("0f857122-73b5-4441-a1f9-70c6b61026b0", "ماهی تن دودی کیان ماهی خزر - 150 گرم",
"4d60246a-3455-45b9-b58c-7d7bc9ddddb5", 30, date(), "گرم", 64800),
("7180fe9c-cdf3-4619-86e7-f9f0275ab469", "اسپیکر خودرو پایونیر مدلTS-6975 V3",
"2ba33d6e-fc05-40da-b28e-3a9197e41955", 2, date(), "دستگاه", 2997000),
("bf60592f-8702-4d05-b171-715e8b7bdb5b", "موتور برق بنزینی رونیکس مدل RH 4708",
"3263d16b-e318-4885-959f-5f4f1fcef4c5", 1, date(), "دستگاه", 6748000),
("2b538f49-59e2-4773-bdd9-42f095b773bb", "سرم پوست بایو آکوا مدل ویتامین C حجم 100 میلی لیتر",
"d7f5c843-8d5c-4bc6-804a-6c80741c787d", 17, date(), "میلی لیتر", 68800);

INSERT INTO stores(storeId, address)
VALUES("fa9b0045-fada-428c-aa28-cb4f7122f08e", "تهران، خیابان زرتشت، نبش کوچه شانزدهم");

INSERT INTO orders(orderId, submissionDate, state, description)
VALUES("e9e4fba0-0be3-4c0a-a81d-5dac3e297640", date(), "PENDING", NULL);

INSERT INTO inventories(inventoryId, roomNumber, floorNumber, shelfNumber)
VALUES("130e459d-b9aa-4c06-a6b9-5eabf9a29869", "S1", "A", "1"),
("9a7bb12b-8a89-4d64-83ac-82e0adc8ead1", "S1", "A", "2"),
("fde700a8-633a-473e-b420-43a55a37e15c", "S1", "A", "3"),
("3801fdf5-ec7c-4f48-87ed-7c112cad6abf", "S1", "B", "1"),
("08db9838-b09e-4967-a4a6-317441b1887a", "S1", "B", "2"),
("ae3e7d48-5e9a-4563-9ed6-5e8dd6531d4b", "S1", "C", "1"),
("ef8d5a1e-2906-4f30-98e2-b889c0da13b1", "S1", "C", "2");

INSERT INTO inventoryProducts(inventoryId, productId)
VALUES("130e459d-b9aa-4c06-a6b9-5eabf9a29869", "c9579fda-bf49-42e2-9056-9a3e2367b484"),
("9a7bb12b-8a89-4d64-83ac-82e0adc8ead1", "0f857122-73b5-4441-a1f9-70c6b61026b0"),
("3801fdf5-ec7c-4f48-87ed-7c112cad6abf", "2b538f49-59e2-4773-bdd9-42f095b773bb");

INSERT INTO orderDetails(orderId, productId, quantity)
VALUES("e9e4fba0-0be3-4c0a-a81d-5dac3e297640", "c9579fda-bf49-42e2-9056-9a3e2367b484", 56),
("e9e4fba0-0be3-4c0a-a81d-5dac3e297640", "0f857122-73b5-4441-a1f9-70c6b61026b0", 12);

INSERT INTO exportOrders(orderId, destinationId, exportDate)
VALUES("e9e4fba0-0be3-4c0a-a81d-5dac3e297640", "fa9b0045-fada-428c-aa28-cb4f7122f08e", "2022-07-03");