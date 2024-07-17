-- Inserimento dati nella tabella ClientiAzienda
INSERT INTO ClientiAzienda (Nome, Sede, Intestatario, PIVA) VALUES
('Azienda Alpha', 'Roma', 'Mario Rossi', 'IT12345678901'),
('Azienda Beta', 'Milano', 'Luca Bianchi', 'IT98765432109'),
('Azienda Gamma', 'Torino', 'Anna Verdi', 'IT11121314151');

-- Inserimento dati nella tabella ClientiPrivati
INSERT INTO ClientiPrivato (Nome, Cognome, DataNascita, CF) VALUES
('Giulia', 'Rossi', '1990-05-10', 'RSSGLI90E50H501S'),
('Marco', 'Bianchi', '1985-11-23', 'BNCMRC85S23H501T'),
('Luca', 'Verdi', '1978-02-15', 'VRDLUC78B15H501N');
