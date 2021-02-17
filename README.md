# Docker_Asp

Project is a stable example how to combine database MySql and REST api on ASP.Net Core.

How to prepare project for runing on machine:
- Download and install Docker
- Clone repository
- Using ``git bash`` go to repository folder: 
```bash
 cd Path/Docker_Asp
```
- Use command:
```
docker-compose build
```
Then:
```
docker-compose up
```

Check the created containers 
```
docker ps -a
```
If the containers exist:
Go to browser by URL http://localhost:8080/comment/1

