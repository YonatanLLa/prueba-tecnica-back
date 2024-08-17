# Proyecto .NET 8

## Descripción

Este proyecto es una aplicación .NET 8 que [breve descripción del propósito del proyecto].

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.
- [Visual Studio 2024](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/) (opcional, pero recomendado).

## Configuración

1. **Clona el repositorio:**

    ```bash
    git clone https://github.com/YonatanLLa/prueba-tecnica-back.git
    ```

2. **Restaurar los paquetes:**

    Asegúrate de estar en la raíz del proyecto y ejecuta el siguiente comando para restaurar los paquetes NuGet necesarios:

3. **Configurar la base de datos:**

    Si tu proyecto usa una base de datos, asegúrate de configurar la cadena de conexión en el archivo `appsettings.json`. Ejemplo:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=tu_base_de_datos;User Id=tu_usuario;Password=tu_contraseña;"
    }
    ```

  ## Paquetes Instalados

Este proyecto utiliza los siguientes paquetes:

- `BCrypt.Net-Next` para el hashing de contraseñas.
- `Microsoft.EntityFrameworkCore` para la interacción con bases de datos.
- `Microsoft.EntityFrameworkCore.SqlServer` para el soporte de SQL Server (o reemplaza con `Microsoft.EntityFrameworkCore.[tu_db_provider]` si usas otro proveedor de base de datos).
- `Microsoft.EntityFrameworkCore.Tools` para herramientas de Entity Framework Core.
- `Microsoft.VisualStudio.Web.CodeGeneration` para la generación de código.
- `Swashbuckle.AspNetCore` para la documentación de la API con Swagger.


