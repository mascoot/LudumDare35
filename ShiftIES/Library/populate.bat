@echo off
for /d /r %%d in (*.*) do (
  echo %%d
  cd %%d
  copy /y nul gitkeep
  cd ../
)

pause