# Mongo-Message with Environment
Verwendung von Environment-Variablen zur Konfiguration der Anwendung.

Build: build.ps1

Starten per Compose: /docker-compose.yml

Starten im Cluster:<br />
1) Netzwerk anlegen: docker network create --attachable -d overlay mongomsg
2) MongoDB starten: docker service create --name messagedb --network mongomsg  mongo:3.2
3) WebApp starten: docker service create --name webapp -p 8687:5000 -e MessageConnectionString=mongodb://messagedb --network mongomsg fpommerening/dotnetinthebox:mongomessage

4) Scale out WebApp (optional): docker service scale webapp=2
