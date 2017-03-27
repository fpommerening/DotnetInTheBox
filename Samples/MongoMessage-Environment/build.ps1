$zip = "c:\Program Files\7-Zip\7z.exe"

& dotnet publish ./src/MongoMessage --configuration Release --output ../../tmp/mongomessage
& $zip a ./dockerfiles/app/mongomessage.7z ./tmp/mongomessage
& docker build -f ./dockerfiles/Dockerfile -t fpommerening/dotnetinthebox:mongomessage ./dockerfiles/