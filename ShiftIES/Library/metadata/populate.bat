for /d /r %%d in (*.*) do 
(
  cd %%d
  copy /y nul gitkeep
  cd ../
)