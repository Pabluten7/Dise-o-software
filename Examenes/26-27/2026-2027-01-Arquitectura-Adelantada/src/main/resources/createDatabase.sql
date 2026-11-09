-- Tabla: DatosContacto
/* Patrones de transformación aplicados:
	 - Clase `DatosContacto` -> tabla `DatosContacto`.
	 - Se añade una clave artificial `id`, ya que la clase no define un identificador propio.
*/
CREATE TABLE DatosContacto (
	id BIGINT PRIMARY KEY,
	nombre VARCHAR(255),
	primerApellido VARCHAR(255),
	segundoApellido VARCHAR(255),
	telefono BIGINT,
	correoElectronico VARCHAR(255)
);

-- Tabla: Candidatura (clase base y subclases)
/* Patrones de transformación aplicados:
	 - Las clases `Candidatura`, `PartidoPolitico`, `Coalicion` y `AgrupacionElectores` se transforman en una única tabla mediante el patrón Single Table.
	 - Se utiliza una columna discriminadora `tipo` para identificar la clase concreta.
	 - Single Table es adecuado porque las tres subclases comparten los atributos `nombre`, `siglas` y `datosRepresentante`, y las relaciones con otras clases del modelo se realizan a través de `Candidatura`. Así se simplifican las consultas polimórficas y se evitan uniones entre tablas de la jerarquía. No se generan columnas específicas de subclase que quedarían nulas: `Coalicion.integrantes` se representa aparte mediante una tabla intermedia.
*/
CREATE TABLE Candidatura (
	id BIGINT PRIMARY KEY,
	nombre VARCHAR(255),
	siglas VARCHAR(100),
	tipo ENUM('PARTIDO_POLITICO', 'COALICION', 'AGRUPACION_ELECTORES') NOT NULL,
	datosRepresentanteId BIGINT,
	FOREIGN KEY (datosRepresentanteId) REFERENCES DatosContacto(id)
);

-- Tabla intermedia: integrantes de una Coalicion
/* Patrones de transformación aplicados:
	 - Association Table Mapping para la relación de muchos a muchos entre `Coalicion` y sus `PartidoPolitico` integrantes.
*/
CREATE TABLE CoalicionIntegrante (
	coalicionId BIGINT,
	partidoPoliticoId BIGINT,
	PRIMARY KEY (coalicionId, partidoPoliticoId),
	FOREIGN KEY (coalicionId) REFERENCES Candidatura(id),
	FOREIGN KEY (partidoPoliticoId) REFERENCES Candidatura(id)
);
