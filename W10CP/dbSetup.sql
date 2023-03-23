CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'the recipe ID',
  title VARCHAR (255) NOT NULL,
  instructions VARCHAR(500) NOT NULL DEFAULT 'No Instructions Provided',
  img VARCHAR(255) NOT NULL,
  category VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL COMMENT 'the creator ID',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO recipes
(title, instructions, img, category, creatorId)
VALUES
('title', 'these are some cool instructions','notImage', 'category', '641b5a46851b5157202b8287');

SELECT 
rec.*,
acc.id,
acc.name,
acc.picture
FROM recipes rec
JOIN accounts acc ON rec.creatorId = acc.id;

UPDATE recipes SET
title = 'this is a updated title',
img = 'THIS IS not an img :O',
category = 'this is an amazing category'
WHERE id = 1;