# pruebaConexionPostgreSQLV
Proyecto que detalla como crear una conexi�n parametrizada a POSTGRESQL.

Lo primero ser� a�adir la librer�a de PostgreSQL: 
bot�n derecho sobre el proyecto> Administrar Paquetes Nuget> Examinar buscar Npgsql> Instalar

Autom�ticamente se configuran todas las referencias en el proyecto:
El archivo pruebaConexionPostgreSQLV.csproj se actualiza.
  <ItemGroup>
    <PackageReference Include="Npgsql" Version="6.0.7" />
  </ItemGroup>