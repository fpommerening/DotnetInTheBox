
$zip = "c:\Program Files\7-Zip\7z.exe"

& dotnet publish ./src/WebApp -c Release -o ./tmp/webapp
& $zip a ./dockerfiles/webapp/app/webapp.7z ./tmp/webapp
& docker build -f ./dockerfiles/webapp/Dockerfile.local -t fpommerening/spartakiade2017-docker:buildoutside ./dockerfiles/webapp/