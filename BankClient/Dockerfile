FROM mcr.microsoft.com/dotnet/framework/runtime:4.8.1 as build-env

WORKDIR ./../

COPY Bankclient/*.* ./Bankclient/
COPY BankSystem/*.* ./BankSystem/

RUN ["dotnet", "build"]

RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/framework/runtime:4.8.1 as runtime
WORKDIR /publish
COPY --from=build-env /publish .

ENTRYPOINT ["dotnet","BankClient.exe"]