CREATE TABLE clients(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE,
	phone VARCHAR(20) NOT NULL UNIQUE,
	address VARCHAR(100) NOT NULL,
	created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO clients(name, email, phone, address)
VALUES
('Tarun Shrestha' , 'tarunshrestha@gmail.com' , '+9779868686881','ktm , Nepal'),
('arun Shrestha' , 'arunshrestha@gmail.com' , '+9779868686882','ktm , Nepal'),
('Trun Shrestha' , 'trunshrestha@gmail.com' , '+9779868686883','ktm , Nepal'),
('Taun Shrestha' , 'taunshrestha@gmail.com' , '+9779868686884','ktm , Nepal'),
('Tarn Shrestha' , 'tarnshrestha@gmail.com' , '+9779868686885','ktm , Nepal')
;