INSERT INTO categories(category_id, name)
VALUES("7c63a09d-8373-4544-a091-376180b75870", "آرایشی و بهداشتی"),
("b-477c-8818-3b77ec87729c", "پوشاک"),
("233fb-fa0b-48dd-a6ba-387e6c279bea", "دیجیتال"),
("60b-1c00-41e6-9d8b-1180cb7a432c", "مواد غذایی"),
("f-17ec-4299-aca3-1fdaa503cb47", "ابزار و تجهیزات صنعتی"),
("7b-bea7-b21a401a75db", "خانگی"),
("83cf8-197f-415a-9384-dde809e5deac", "متفرقه");

INSERT INTO products(product_id, name, category_id, stock, 
submission_date, unit, price)
VALUES("bf77de57-5289-4b39-86b3-8c75459e49a0", "میز ناهارخوری ناصر پلاستیک مدل 323", 
"5012cb7d-0b86-4c7b-bea7-b21a401a75db", 35, date(), "عدد", 2080000),
("bd9d7843-1323-4dd3-8795-61a56edd58ce", "شلوار مردانه پنبه شکار مدل اسلش شش جیب",
"af66095c-8c8b-477c-8818-3b77ec87729c", 12, date(), "عدد", 100400),
("fd18452e-5d51-4e99-bcf3-e0c8cd87e0d7", "خامه ترش کاله - 200 گرم",
"1060060b-1c00-41e6-9d8b-1180cb7a432c", 101, date(), "گرم", 25000),
("451c4a71-b25f-4120-866e-4fa32b1a8997", "ماهی تن دودی کیان ماهی خزر - 150 گرم",
"1060060b-1c00-41e6-9d8b-1180cb7a432c", 30, date(), "گرم", 64800),
("be4f72fa-edb1-4f7e-8cc9-c051b35d5280", "اسپیکر خودرو پایونیر مدلTS-6975 V3",
"886233fb-fa0b-48dd-a6ba-387e6c279bea", 2, date(), "دستگاه", 2997000),
("bad348e5-5fa7-40aa-8b0d-07c15e61de8e", "موتور برق بنزینی رونیکس مدل RH 4708",
"115457bf-17ec-4299-aca3-1fdaa503cb47", 1, date(), "دستگاه", 6748000),
("eebab6cc-954e-476a-99fb-bb28bfe30fce", "سرم پوست بایو آکوا مدل ویتامین C حجم 100 میلی لیتر",
"7c63a09d-8373-4544-a091-376180b75870", 17, date(), "میلی لیتر", 68800);

INSERT INTO inventory_partitions(partition_id, room_number, floor_number, shelf_number)
VALUES("c8592779-2e91-43c9-bf1c-1b5b3c9f0b88", "S1", "A", "1"),
("bda3fb74-2cb8-410a-a56f-a22633bb6e97", "S1", "A", "2"),
("cb07ac4f-e660-4301-b18b-25fb40c69a44", "S1", "A", "3"),
("37403c74-ab9a-467f-824a-4b53b79d30d4", "S1", "B", "1"),
("9163ab26-4094-471c-b300-c88741d6a4fa", "S1", "B", "2"),
("6d412075-19f9-426d-8e70-5da6c341defe", "S1", "C", "1"),
("c13e896b-bf03-4290-9c67-2cbd5aa56059", "S1", "C", "2");

INSERT INTO inventory_products(partition_id, product_id)
VALUES("c8592779-2e91-43c9-bf1c-1b5b3c9f0b88", "fd18452e-5d51-4e99-bcf3-e0c8cd87e0d7"),
("bda3fb74-2cb8-410a-a56f-a22633bb6e97", "451c4a71-b25f-4120-866e-4fa32b1a8997"),
("37403c74-ab9a-467f-824a-4b53b79d30d4", "eebab6cc-954e-476a-99fb-bb28bfe30fce");

INSERT INTO orders(order_id, submission_date, state, description)
VALUES("d089fae4-acbe-4a27-90e8-c0033d5ef2dc", date(), "PENDING", NULL);

INSERT INTO order_details(order_id, product_id, quantity)
VALUES("d089fae4-acbe-4a27-90e8-c0033d5ef2dc", "fd18452e-5d51-4e99-bcf3-e0c8cd87e0d7", 56),
("d089fae4-acbe-4a27-90e8-c0033d5ef2dc", "451c4a71-b25f-4120-866e-4fa32b1a8997", 12);

INSERT INTO store_branches(branch_id, address)
VALUES("273830dc-c063-4d11-8abd-1bf7b1acb420", "تهران، خیابان زرتشت، نبش کوچه شانزدهم");


INSERT INTO export_orders(order_id, destination_id, export_date)
VALUES("d089fae4-acbe-4a27-90e8-c0033d5ef2dc", "273830dc-c063-4d11-8abd-1bf7b1acb420", "2022-07-03");