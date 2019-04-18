# Prueba .net Consultoria Organizacional

Es una prueba t�cnica de desarrollo para Consultoria Organizacional

## Pasos

1. Clone el respectivo repositorio o descargue los fuentes.
	```bash
		git clone https://github.com/edwinborda/ConsultoriaLaSanteTest
	```
2. Abra la soluci�n en visual studio y restaure los paquetes de nugget si es necesario

3. Ir al proyecto de 'ConsultoriaLaSante.DataAccess' y abrir la consola de nuget, desde Herramientas > Administrador de paquetes Nuget

4. Modificar la cadena de conexi�n en App.config
	```xml
		 <connectionStrings>
			<add name="connectionString" connectionString="Data Source=***; Initial Catalog=ConsultoriaLaSanteDB; User Id=**; Password=***"  providerName="System.Data.SqlClient"/>
		 </connectionStrings>
	```
5. Correr la migracion desde la consola de nuget
	```bash
		 Update-Database -Verbose
	```
	
6. Cambiar la cadena de conexi�n del punto 4. tambi�n en 'ConsultoriaLaSante.Api'

7. Ejecutar la aplicaci�n. (Por defecto ejecuta el API)

8. Desde la soluci�n de Visual Studio situarse en el proyecto 'ConsultoriaLaSante.Web' y dar click derecho 'Depurar' > 'Iniciar nueva instancia'

## License
 Creado y Modificado por Edwin Borda edwin.borda@outlook.com

