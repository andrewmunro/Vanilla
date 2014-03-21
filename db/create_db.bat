sqlcmd -S .\SQLExpress -Q "RESTORE DATABASE mangos FROM DISK = 'mangos.bak' WITH REPLACE"
sqlcmd -S .\SQLExpress -Q "RESTORE DATABASE realmd FROM DISK = 'realmd.bak' WITH REPLACE"
sqlcmd -S .\SQLExpress -Q "RESTORE DATABASE characters FROM DISK = 'characters.bak' WITH REPLACE"