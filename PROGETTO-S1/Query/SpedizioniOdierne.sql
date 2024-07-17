SELECT * FROM Spedizioni s 
JOIN StatoSpedizione st ON s.IdSpedizione = st.FK_IdSpedizione 
WHERE st.Stato = 'In Consegna' AND CONVERT(DATE, DataConsegnaPrev) = CAST(GETDATE() AS DATE);
