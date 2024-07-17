-- Inserimento dati nella tabella StatoSpedizione
INSERT INTO StatoSpedizione (Stato, Luogo, Descrizione, DataOraAggiornamento, FK_IdSpedizione) VALUES
('In preparazione', 'Magazzino Centrale', 'La spedizione è in fase di preparazione.', '2024-07-01T08:00:00', 3),
('Spedito', 'Centro di Smistamento', 'La spedizione è stata inviata dal centro di smistamento.', '2024-07-01T12:00:00', 3),
('In transito', 'Roma', 'La spedizione è in transito verso la destinazione.', '2024-07-02T09:00:00', 3),
('Consegnato', 'Roma', 'La spedizione è stata consegnata al destinatario.', '2024-07-03T14:00:00', 3),

('In preparazione', 'Magazzino Milano', 'La spedizione è in fase di preparazione.', '2024-07-02T08:00:00', 4),
('Spedito', 'Centro di Smistamento', 'La spedizione è stata inviata dal centro di smistamento.', '2024-07-02T12:00:00', 4),
('In transito', 'Milano', 'La spedizione è in transito verso la destinazione.', '2024-07-03T10:00:00', 4),
('Consegnato', 'Milano', 'La spedizione è stata consegnata al destinatario.', '2024-07-05T16:00:00', 4),

('In preparazione', 'Magazzino Torino', 'La spedizione è in fase di preparazione.', '2024-07-03T08:00:00', 5),
('Spedito', 'Centro di Smistamento', 'La spedizione è stata inviata dal centro di smistamento.', '2024-07-03T11:00:00', 5),
('In transito', 'Torino', 'La spedizione è in transito verso la destinazione.', '2024-07-04T09:00:00', 5),
('Consegnato', 'Torino', 'La spedizione è stata consegnata al destinatario.', '2024-07-07T13:00:00', 5),

('In preparazione', 'Magazzino Roma', 'La spedizione è in fase di preparazione.', '2024-07-04T08:00:00', 6),
('Spedito', 'Centro di Smistamento', 'La spedizione è stata inviata dal centro di smistamento.', '2024-07-04T12:00:00', 6),
('In transito', 'Roma', 'La spedizione è in transito verso la destinazione.', '2024-07-05T09:00:00', 6),
('Consegnato', 'Roma', 'La spedizione è stata consegnata al destinatario.', '2024-07-06T14:00:00', 6),

('In preparazione', 'Magazzino Napoli', 'La spedizione è in fase di preparazione.', '2024-07-05T08:00:00', 7),
('Spedito', 'Centro di Smistamento', 'La spedizione è stata inviata dal centro di smistamento.', '2024-07-05T11:00:00', 7),
('In transito', 'Napoli', 'La spedizione è in transito verso la destinazione.', '2024-07-06T10:00:00', 7),
('Consegnato', 'Napoli', 'La spedizione è stata consegnata al destinatario.', '2024-07-08T15:00:00', 7),

('In preparazione', 'Magazzino Milano', 'La spedizione è in fase di preparazione.', '2024-07-06T08:00:00', 8),
('Spedito', 'Centro di Smistamento', 'La spedizione è stata inviata dal centro di smistamento.', '2024-07-06T12:00:00', 8),
('In transito', 'Milano', 'La spedizione è in transito verso la destinazione.', '2024-07-07T09:00:00', 8),
('Consegnato', 'Milano', 'La spedizione è stata consegnata al destinatario.', '2024-07-09T11:00:00', 8);
