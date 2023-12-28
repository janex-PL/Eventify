# Step 1: Build the project
# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the csproj and restore any dependencies (via NuGet)
COPY ["Eventify.Frontend.WebAssembly/Eventify.Frontend.WebAssembly.csproj", "Eventify.Frontend.WebAssembly/"]
COPY ["Eventify.Frontend.Application/Eventify.Frontend.Application.csproj", "Eventify.Frontend.Application/"]
COPY ["Eventify.Frontend.Infrastructure/Eventify.Frontend.Infrastructure.csproj", "Eventify.Frontend.Infrastructure/"]
RUN dotnet restore "Eventify.Frontend.WebAssembly/Eventify.Frontend.WebAssembly.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/Eventify.Frontend.WebAssembly"
RUN dotnet build "Eventify.Frontend.WebAssembly.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Eventify.Frontend.WebAssembly.csproj" -c Release -o /app/publish

# Step 2: Build the runtime image
# Use Nginx to serve the static files
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Remove default nginx static assets
RUN rm -rf ./*

# Copy static assets from builder stage
COPY --from=publish /app/publish/wwwroot .
COPY Eventify.Frontend.WebAssembly/nginx.conf /etc/nginx/nginx.conf

# Expose port 80 for the web server
EXPOSE 80

# Start Nginx and keep it running
CMD ["nginx", "-g", "daemon off;"]
