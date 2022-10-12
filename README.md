# pruebaConexionPostgreSQLV
Proyecto que detalla como crear una conexión parametrizada a POSTGRESQL.

Lo primero será añadir la librería de PostgreSQL: 
botón derecho sobre el proyecto> Administrar Paquetes Nuget> Examinar buscar Npgsql> Instalar

Automáticamente se configuran todas las referencias en el proyecto:
El archivo pruebaConexionPostgreSQLV.csproj se actualiza.
  <ItemGroup>
    <PackageReference Include="Npgsql" Version="6.0.7" />
  </ItemGroup>