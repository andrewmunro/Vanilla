copy "mangos.bak" "C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup\mangos.bak"
copy "realmd.bak" "C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup\realmd.bak"
copy "characters.bak" "C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup\characters.bak"

sqlcmd -S .\SQLExpress -Q "RESTORE DATABASE mangos FROM DISK = 'mangos.bak' WITH REPLACE"
sqlcmd -S .\SQLExpress -Q "RESTORE DATABASE realmd FROM DISK = 'realmd.bak' WITH REPLACE"
sqlcmd -S .\SQLExpress -Q "RESTORE DATABASE characters FROM DISK = 'characters.bak' WITH REPLACE"

del "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\mangos.bak"
del "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\realmd.bak"
del "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\characters.bak"