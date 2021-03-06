FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Install node
ENV NODE_VERSION 8.9.4
ENV NODE_DOWNLOAD_SHA 21fb4690e349f82d708ae766def01d7fec1b085ce1f5ab30d9bda8ee126ca8fc
RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs
RUN npm i npm@latest -g
#RUN npm install gulp -g
#RUN npm install webpack -g

# Lets Copy necessary files and restore as unique layers
COPY *.csproj ./
RUN dotnet restore -s https://api.nuget.org/v3/index.json -s https://www.myget.org/F/ccms/api/v3/index.json

# Copy the rest and build
COPY . ./
RUN npm install
#RUN webpack --config webpack.config.js
RUN dotnet publish -c Release -o out

#Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build-env /app/out .

# Expose our ports
EXPOSE 7000/tcp
ENV ASPNETCORE_URLS http://*:7000
HEALTHCHECK --interval=30s --timeout=3s --retries=1 CMD curl --silent --fail http://localhost:7000/hc || exit 1

# START
ENTRYPOINT ["dotnet", "Dashboard.WebApplication.dll"]