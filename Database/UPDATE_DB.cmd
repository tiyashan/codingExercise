
@echo off
echo =======================================
echo ==  Patch SQL Databases   ==
echo =======================================

set /p dbserver=Database Server:
set /p dbname=Database Name:
set /p dbuser=Database User:
set /p dbpassword=Password:
set dir=.
set log_folder=logs

set folder_list=(Tables StoredProcedures)

echo Updating database ...

for %%a in %folder_list% do (
	mkdir %dir%\%log_folder%\%%a
	
	for /f "delims=" %%b in ('dir /b /o:n "%dir%\%%a\*.sql"') do (
		echo Running %%a\%%b 
		sqlcmd -S %dbserver% -U %dbuser% -P %dbpassword% -d %dbname% -i "%dir%\%%a\%%b" >> "%dir%\logs\%%a\%%b.log"
	)
	
	for /f "delims=" %%b in ('dir /b /o:n /a:d "%dir%\%%a"') do (
		mkdir %dir%\%log_folder%\%%a\%%b
		
		for /f %%c in ('dir /b /o:n "%dir%\%%a\%%b\*.sql"') do (
			echo Running %%a\%%b\%%c
			sqlcmd -S %dbserver% -U %dbuser% -P %dbpassword% -d %dbname% -i "%dir%\%%a\%%b\%%c" >> "%dir%\%log_folder%\%%a\%%b\%%c.log"
		)
	)
)
echo done
pause