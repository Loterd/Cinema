## Run and test
- run via IDE or using 'dotnet run'
- create a postgres DB, and specify in 'launchSettings.json' connection string
- run in terminal 'dotnet ef database update'

## Some details
Endpoints and models are described in swagger

I used in this test task MediatR for split domains into three groops:
- Movies
- Theater,Showtime
- UserReservation
- 
so it can be splited in the 3 microservices if needed in future, you just need to chaange MediatR implementations with the Kafka for example

## Possible future improvements
- Add more unit reasonable tests (were not added due to lack of time)
- Add more json documentation (were not added due to lack of time)
