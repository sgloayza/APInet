# API en .NET

## Descripción
Esta API en .NET proporciona servicios para [breve descripción de lo que hace la API]. Permite a los usuarios [explicar la funcionalidad principal de la API en términos simples].

## Tecnologías Utilizadas
- .NET Core/.NET 5
- C#
- ASP.NET Core Web API

## Ramas
El repositorio tiene dos ramas principales:

- **main**: Utiliza ASP.NET Core Web API. Es adecuado para proyectos de cualquier tamaño y sigue el modelo MVC para estructurar el código.
  
- **minimalapi**: Utiliza ASP.NET Core Minimal API. Esta rama está orientada a proyectos pequeños, demos, microservicios y Azure Functions. Utiliza el mapeo de rutas con funciones y es menos complejo de escalar en proyectos de alta complejidad.

## Configuración
Para ejecutar y probar la API en tu máquina local, asegúrate de tener instalado lo siguiente:
- .NET Core/.NET 5 SDK
- EntityFramework Core v8.0.3
- EntityFramework In Memory v8.0.3
- EntityFramework Sqlserver v8.0.3

### Pasos para Ejecutar la API
1. **Clonar el Repositorio**: 
    ```bash
    git clone https://github.com/sgloayza/APInet.git
    ```

2. **Navegar al Directorio del Proyecto**:
    ```bash
    cd APInet
    ```

3. **Compilar el Proyecto**:
    ```bash
    dotnet build
    ```

4. **Ejecutar la Aplicación**:
    ```bash
    dotnet run
    ```

5. **Acceder a la API**:
    La API estará disponible en la URL `https://localhost:5202`.
