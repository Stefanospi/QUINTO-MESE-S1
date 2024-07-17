-- Inserimento dati nella tabella Spedizioni
INSERT INTO Spedizioni (DataSpedizione, NumId,Peso, CittaDestinatario, Indirizzo, NomeDestinatario, CostoSpedizione, DataConsegnaPrev, FK_ClienteAzienda, FK_ClientePrivato) VALUES
('2024-07-01',7124987, 3.0, 'Roma', 'Via Appia, 10', 'Mario Rossi', 25.50, '2024-07-03', 1, NULL),
('2024-07-02',2142114, 2.5, 'Milano', 'Via Milano, 22', 'Luca Bianchi', 18.75, '2024-07-05', 2, NULL),
('2024-07-03',1241241, 4.0, 'Torino', 'Corso Torino, 55', 'Anna Verdi', 30.00, '2024-07-07', 3, NULL),
('2024-07-04',1242142, 1.5, 'Roma', 'Via Nazionale, 45', 'Giulia Rossi', 12.50, '2024-07-06', NULL, 1),
('2024-07-05',3463466, 3.2, 'Napoli', 'Via Napoli, 30', 'Marco Bianchi', 22.00, '2024-07-08', NULL, 2),
('2024-07-06',0985730, 2.0, 'Milano', 'Via Torino, 5', 'Luca Verdi', 15.75, '2024-07-09', NULL, 3);
