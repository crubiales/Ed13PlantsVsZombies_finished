@echo off
SETLOCAL EnableExtensions >NUL
set EXE=devenv.exe >NUL
FOR /F %%x IN ('tasklist /NH /FI "IMAGENAME eq %EXE%"') DO IF %%x == %EXE% goto FOUND >NUL
@echo on
git config --global user.name"VGC"
git config --global user.email "alumno@viralgamingacademy.com"
git add -A
git commit -m alumno
git fetch origin master
git merge -s recursive -X theirs origin/master
pause
goto FIN
:FOUND
@echo off
echo VISUAL STUDIO ESTA SIENDO EJECUTADO. POR FAVOR, CIERRA VISUAL STUDIO PARA ACTUALIZAR EL REPOSITORIO GIT.
pause
:FIN