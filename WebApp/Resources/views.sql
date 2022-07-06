CREATE VIEW v_products
AS
SELECT p.product_id as productId,
            p.name, p.unit, p.price, p.stock, p.submission_date as submissionDate,
            c.category_id as categoryId, c.name
            from products p join categories c
            on p.category_id = c.category_id;