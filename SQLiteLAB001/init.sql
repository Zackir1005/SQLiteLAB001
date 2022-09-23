CREATE TABLE workplace (
    id       INTEGER         PRIMARY KEY ASC AUTOINCREMENT,
    name     VARCHAR (1, 50),
    display  VARCHAR (1, 50),
    keyboard VARCHAR (1, 50),
    mouse    VARCHAR (1, 50) 
);
"CREATE TABLE workplace (id INTEGER PRIMARY KEY ASC AUTOINCREMENT, name VARCHAR (1, 50), display  VARCHAR (1, 50), keyboard VARCHAR (1, 50), mouse VARCHAR (1, 50));"
"INSERT INTO workplace (name, display, keyboard, mouse) VALUES ( 'WorkPC001', 'Disp001', 'Keyboard001', 'Mouse001');"

INSERT INTO workplace (
                         name,
                         display,
						 keyboard,
						 mouse
                     )
                     VALUES (
                         'WorkPC001',
                         'Disp001',
						 'Keyboard001',
						 'Mouse001'
                     );
UPDATE workplace SET name = 'WorkPC002',
					display = 'Disp002'
					WHERE id = 2;
SELECT * FROM  WHERE name LIKE '%PC%';
SELECT name, display FROM workplace WHERE name = 'WorkPC001';
DELETE FROM workplace WHERE id >= 3;