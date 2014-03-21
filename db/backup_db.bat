sqlcmd -S .\SQLExpress -Q "BACKUP DATABASE mangos TO DISK = 'mangos.bak'"
sqlcmd -S .\SQLExpress -Q "BACKUP DATABASE realmd TO DISK = 'realmd.bak'"
sqlcmd -S .\SQLExpress -Q "BACKUP DATABASE characters TO DISK = 'characters.bak'"

move "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\mangos.bak" "mangos.bak"
move "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\realmd.bak" "realmd.bak"
move "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Backup\characters.bak" "characters.bak"