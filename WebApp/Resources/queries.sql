SELECT product_id, products.name as product_name, categories.name as category_name, stock, submission_date, unit, price  
from products join categories on products.category_id = categories.category_id;

SELECT products.product_id, name, room_number || "-" || floor_number || "-" || shelf_number as storage_location FROM products 
LEFT JOIN inventory_products on products.product_id = inventory_products.product_id 
LEFT JOIN inventory_partitions on inventory_products.partition_id = inventory_partitions.partition_id;