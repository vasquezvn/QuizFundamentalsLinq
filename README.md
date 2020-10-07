# QuizFundamentalsLinq
LINQ BASICs
LINQ FUNDAMENTALS - EXERCISES
- An Introduction
	> Listar los 5 archivos mas pesados dentro de un directorio
		* Get all files from selected path
		* Sort Files collection
			* Implement Icomparer to sort by Lenght
		* Delimited number of results
	> Listar los 5 archivos mas pesados dentro un directorio usando Linq
		* usando sintaxis de query
		* usando sintaxis de method

- LINQ and C#
	> Implementar metodos agregados a clases, interfaces
		* crear una clase
			- movie
				title
				rating
				year
		* implementar metodos agregados 
			- Implementar un metodo agregado a la clase Movie para obtener la cantidad de letras que tiene el titulo de la pelicula
			
	> Filtrar capitales por algun criterio e implementar lambda expressions junto al metodo Linq Where
		* Crear un named method lambda
		* Crear un Anonynous Method lambda
		* Crear una expression lambda
		
	> Crear funciones Func
		* Crear Func de un solo parametro
		* Crear Func de dos o mas parametros
		
	> A partir de una lista, tomar solo aquellos que tengan una longitud de 5 y que estos se ordened bajo un criterio
		* Utilizar el method Where para filtrar
		* Utilizar el metodo OrderBy para ordernar
		
	> Obtener todas las ciudades que inicien con L y que tengan una longitud menor a 15 caracteres por consultas por query y method
		* Crear una coleccion con ciudades
		* Filtrar utilizando method sintax
		* Filtrar utilizando query sintax
		* Ordenar el resultado alfabeticamente

- LINQ Queries
	> Crear tu propio filter para funcion Where de LINQ
		* Crear una clase con diferentes atributos
		* crear una clase aparte para funciones agregadas
		* crear el metodo que sustituya el metodo Where
	> tomar los primeros 10 datos de una collecion infinita
		* crear un metodo que retorne una sucession de numeros aletarios en un bucle infinito
		* llamar al metodo y delimitar su numero a 10
		* imprimir resultado

- Filter, Ordering & Projecting => DONE
	> crear objetos desde un CSV
		* filtrar los datos del CSV
		* proyectar los datos
		* devolver una lista de objetos
		* utilizar method syntax y Query syntax para obtener los objetos desde el CSV
		
	> Crear una consulta para obtener el top ten autos que tenga la mejor eficiencia de combustible y tambien los que tengan menos eficiencia
		* que muestre el nombre del auto y su rendimiento (Name, Combined)
		* en caso de tener varios autos con la misma eficiencia, ordernar por segundo criterio de nombre
		* utilizar method y query sintax

	> Usar el operador filter para seleccionar los autos que tengan mejor rendimiento para una marca en especifico
		* agregar un segundo filtro y que filtre a los autos con el año mayor a 2016
		* realizar el ejercicio con query y method sintax
		
	> Verificar si la coleccion tiene algun dato, si todos los datos son de un tipo en especifico
	
	> Dada una coleccion
		* Proyectar todos sus valores para devolver un tipo de dato en especifico como Car
		* Utilizar extension methods para proyectar el valor que se requiere por ejemplo Car
	> Dada una coleccion
		* proyectar un objeto anonimo para tomar solo los valores con los que nos interesa trabajar de un CSV por ejemplo manufacturer, name, combined
		* 

- Joining, Grouping & Aggregating
	DONE > Dado un segundo file CSV
		* definir un nuevo objeto que represente el nuevo documento
		* convertir el archivo en una lista de objetos para trabajar en memoria
		
	DONE > listar los diez vehiculos mas eficientes y que muestre la localizacion de cada marca
		* Utilizar el operador Join para unir las dos listas de objetos
		* mantener el order de los objetos
		* realizar la operacion para method y query syntax
		
	**DONE > Enlazar dos listas por mas de un criterio
		* crear objetos anonimos de los datos que se quieren enlazar
		* asegurarse de que estos atributos que se enlazan tengan el mismo nombre
		* realizar este enlazado para method y query syntax
		
	DONE > Grouping: AGRUPAR POR MARCA Y MOSTRAR EL NUMERO TOTAL DE AUTOS POR MARCA
		* listar todas las marcas de autos con su respectiva cantidad de autos existentes en la lista
		* eliminar repetidos, minusculas, mayusculas, etc  
		* ordenar 
		
	*DONE > Agrupar por marca y obtener los dos autos con mejor rendimiento por cada marca
		* agrupar por auto
		* asignar la agrupacion a una variable
		* ordenar por nombre de marca
		* proyectar todo el objeto
		* imprimir el nombre de la marca y despues el nombre de los dos autos con mejor redimiento y mostrar el nombre y su rendimiento
		* realizarlo por query y method syntax

	DONE > Group-Join: Obtener la lista de los dos vehiculos mas eficientes por marca y el pais al que pertenecen
		* Unir las dos listas empezando por la lista que tiene el atributo que nos interesa que es Marca
		* encapsular la union de las dos listas
		* proyectar los dos listas dentro de un nuevo objeto
		* realizar el recorrido por el objeto anonimo utilizando el nombre
		* mostrar el nombre de la marca y el lugar de procedencia
		* utilizar el segundo objeto dentro dentro del objeto anonimo y llamar a los atributos de Car para lista el nombre y su rendimiento
		* realizar la consulta por query y method syntax
		Method:
		* utilizar el metodo groupJoin
		
	**Done > EXERCISE: Obtener los tres vehiculos mas eficientes por pais
		* unir las dos listas
		* crear una variable para manipular la informacion de agrupacion
		* crear un objeto anonimo
		* Encapsular todo el resultado en otra variable
		* agrupar por pais
		* imprimer por key y despues utilizar SelectMany para recorrer por los valores de Car

	DONE > Aggreation Query Syntax: Dada una lista de objetos, agrupar los valores y obtener el max, min y avg de los items agrupados
		* agrupar
		* manipular los datos dentro una variable
		* proyectar dentro de un objeto anonimo
		* obtener el max, min, avg
		* ordenar la coleccion incluyendo los datos en una variable
		* ordenar de manera decendente
			
	**Done > Aggregation Method syntax: Dada una lista de objetos, obtener el max, min y avg de rendimiento por cada marca de auto en una sola busqueda
		* agrupar por el criterio requerido
		* retornar un objeto nuevo
		* utilizar el metodo aggregate
			- crear una clase aggregation
			- crear un metodo que haga el calculo de la informacion que requerimos min, mas, avg
			- crear un metodo que haga el calculo final de lo requerido (avg) 
			
- LINQ to XML
	*Done > Crear un XML a partir de una lista IEnumerable
		* Utilizar los elementos XML: XDocument, XElement y XAttribute
		
	*Done > Realizar una consulta a aun archivo XML: Listar a todos los autos de marca BWM
		* revisar los diferentes metodos para cargar los datos desde el archivo XML
		
	**Done> Utilizar Namespaces para crear y para realizar la consulta
		* crear un namespace para el root
		* crear un namespace para los elements
		* consultar al archivo XML con los namespaces incluidos
		* agregar una alias al namespace del root para trabajar desde el root con los elementos
		* realizar consultas a prueba de averias

- LINQ and the Entity Framework
	DONE > Configuracion del proyecto
		- Conectarse a la DB local desde Visual Studio
		- Agregar el Entity framework package al proyecto
		- Modificar la clase que almacena los datos para Car agregando un identificador
		- Crear una clase que represente una base de datos para Cars y que tenga un atributo que nos permita la manipulacion de una tabla
	
	DONE > Insertar datos a la base de datos
		- Crear el metodo que nos permitira insertar datos a la DB
		- Inicializar la base de datos para que haga la manipulacion de datos cuando se realice alguna modificacion
		- Crear una instancia de la clase que define la base de datos
		- Crear un ciclo para insertar todos los datos de la coleccion Cars
		- Guardar los datos
		
	Done > Obtener los 10 autos mas eficientes de la marca BMW
		- Crear una instancia de la clase de administra la DbContext
		- realizar la consulta sobre el objeto instanciado por query y method syntax
		- mostrar los logs en base de datos
		- mostrar los datos por consola
