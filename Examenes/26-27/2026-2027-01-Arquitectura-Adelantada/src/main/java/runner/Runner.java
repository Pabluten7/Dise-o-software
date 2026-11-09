package runner;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.sql.Connection;
import java.nio.charset.StandardCharsets;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

import org.h2.tools.Console;
import org.h2.tools.RunScript;

import databaseConnection.DbConnectionPool;
import domain.AgrupacionElectores;
import domain.Candidatura;
import domain.Coalicion;
import domain.Circunscripcion;
import domain.DatosContacto;
import domain.EstadoLista;
import domain.Impugnacion;
import domain.ListaCongreso;
import domain.ListaElectoral;
import domain.PartidoPolitico;
import dto.CircunscripcionListasDTO;
import dto.ListaCircunscripcionesAssembler;
import dto.ListaCircunscripcionesDTO;
import dto.ListaResumenDTO;
import exceptions.PersistenceException;
import proxy.ListaCongresoProxy;
import service.ListaService;

/**
 * Clase que sirve como punto de entrada a la aplicacion.
 * 
 * @author Pablo Sanchez
 *
 */
public class Runner {

	/**
	 * Punto de entrada principal a la aplicacion.
	 * 
	 * @param args Argumentos de entrada. En nuestro caso, simplemente se ignoran.
	 * @throws IOException          Excepcion de entrada al leer desde teclado que
	 *                              no debería saltar nunca.
	 * @throws SQLException         Excepcion de SQL que puede saltar al iniciar la
	 *                              consola de H2.
	 * @throws PersistenceException Excepcion de persistencia que puede saltar al
	 *                              ejecutar operaciones que impliquen acceso a BD.
	 */
	public static void main(String[] args) {

		try {

			// Iniciar consola H2 para depuracion
			Console.main();

			// Pregunta 3
			initializeDatabase();

			// Pregunta 4
			testService();

			// Pregunta 5
			testDTO();

			// Pregunta 7
			testProxy();

			System.out.println();
			System.out.println("Pulse INTRO para salir");
			System.in.read();
			System.out.println("Aplicacion terminada");

		} catch (SQLException e) {
			e.printStackTrace();
		} catch (PersistenceException e) {
			e.printStackTrace();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} // try-catch

		System.exit(0);

	} // main

	/**
	 * Crea la base de datos de la aplicacion y la inicializa con algunos
	 * datos necesarios para probar la aplicacion.
	 * 
	 * @throws PersistenceException  Excepcion de persistencia generada durante la
	 *                               inicializacion de la base de datos.
	 * @throws FileNotFoundException Excepcion generada al acceder a los archivos de
	 *                               creacion e inicializacion de la base de datos.
	 * @throws SQLException          Excepcion SQL generada por alguna operación de
	 *                               H2.
	 */
	private static void initializeDatabase() throws PersistenceException, IOException, SQLException {

		System.out.println("Inicializando la base de datos.");

		Connection conn = DbConnectionPool.getInstance().getConnection();

		System.out.println("Conexion a la base de datos creada.");
		System.out.println("Creando tablas.");

		RunScript.execute(conn, new FileReader("src/main/resources/createDatabase.sql", StandardCharsets.UTF_8));

		System.out.println("Tablas creadas.");
		System.out.println("Alimentando con datos la base de datos.");

		RunScript.execute(conn, new FileReader("src/main/resources/feedDatabase.sql", StandardCharsets.UTF_8));

		System.out.println("Base datos inicializada.");
		System.out.println();

	} // initialiseDatabase

	/**
	 * Caso de prueba para el service (Pregunta 4).
	 * 
	 * @throws PersistenceException Excepcion generada durante el acceso a la base
	 *                              de datos.
	 */
	private static void testService() throws PersistenceException {

		ListaService service = new ListaService();

		System.out.println("Probando ListaService.anhadirCandidato");
		System.out.println();

		// Lista 0 (borrador, 3 congresistas, 5 escaños): el candidato es titular
		DatosContacto titular = nuevoCandidato(1000, "Candidato titular");
		System.out.println("Lista 0 (borrador, 3 de 5 titulares): "
				+ service.anhadirCandidato(0, titular));

		// Lista 1 (borrador, 6 congresistas, 5 escaños): el candidato es suplente
		DatosContacto suplente = nuevoCandidato(1001, "Candidato suplente");
		System.out.println("Lista 1 (borrador, 6 con 5 escaños): "
				+ service.anhadirCandidato(1, suplente));

		// Lista 2 (presentada): el candidato queda excluido
		DatosContacto excluido = nuevoCandidato(1002, "Candidato excluido");
		System.out.println("Lista 2 (presentada): "
				+ service.anhadirCandidato(2, excluido));

		System.out.println();

	} // testService

	private static DatosContacto nuevoCandidato(long id, String nombre) {

		DatosContacto candidato = new DatosContacto();
		candidato.setId(id);
		candidato.setNombre(nombre);
		return candidato;

	} // nuevoCandidato

	/**
	 * Caso de prueba para los DTOs (Pregunta 5).
	 */
	private static void testDTO() {

		System.out.println("Probando DTO: pantalla de gestion de listas (Figura 2)");

		Circunscripcion cantabria = crearCircunscripcion("Cantabria", 5, 4);

		// Partido Alfa: proclamada, 9 candidatos (5 titulares y 4 suplentes)
		ListaCongreso listaAlfa = crearListaCongreso(crearPartidoPolitico("Partido Alfa", "PA"), EstadoLista.PROCLAMADA,
				cantabria);

		listaAlfa.getCongresistas().add(nuevoCandidato(0, "Ana Pérez Ruiz"));
		listaAlfa.getCongresistas().add(nuevoCandidato(1, "Bruno Martín López"));
		listaAlfa.getCongresistas().add(nuevoCandidato(2, "Clara Sánchez Vega"));
		listaAlfa.getCongresistas().add(nuevoCandidato(3, "Diego Romero Gil"));
		listaAlfa.getCongresistas().add(nuevoCandidato(4, "Elena Torres Vidal"));
		listaAlfa.getCongresistas().add(nuevoCandidato(5, "Félix Navarro León"));
		listaAlfa.getCongresistas().add(nuevoCandidato(6, "Inés Castro Mora"));
		listaAlfa.getCongresistas().add(nuevoCandidato(7, "Javier Molina Ríos"));
		listaAlfa.getCongresistas().add(nuevoCandidato(8, "Lucía Herrera Soler"));
		cantabria.getListasPresentadas().add(listaAlfa);

		// Coalición Beta: presentada, 15 candidatos (5 titulares y 10 suplentes)
		ListaCongreso listaBeta = crearListaCongreso(crearCoalicion("Coalición Beta", "CB"),
				EstadoLista.PRESENTADA, cantabria);
		listaBeta.getCongresistas().add(nuevoCandidato(100, "Luis Gómez Soto"));
		listaBeta.getCongresistas().add(nuevoCandidato(101, "Marta Ruiz Vega"));
		listaBeta.getCongresistas().add(nuevoCandidato(102, "Pablo Serrano Gil"));
		listaBeta.getCongresistas().add(nuevoCandidato(103, "Nuria Campos León"));
		listaBeta.getCongresistas().add(nuevoCandidato(104, "Iván Ortega Soler"));
		listaBeta.getCongresistas().add(nuevoCandidato(105, "Elisa Navarro Cruz"));
		listaBeta.getCongresistas().add(nuevoCandidato(106, "Hugo Medina Ríos"));
		listaBeta.getCongresistas().add(nuevoCandidato(107, "Alicia Fuentes Mora"));
		listaBeta.getCongresistas().add(nuevoCandidato(108, "Marcos Vidal Rey"));
		listaBeta.getCongresistas().add(nuevoCandidato(109, "Sara Prieto Luna"));
		listaBeta.getCongresistas().add(nuevoCandidato(110, "Daniel Castillo Peña"));
		listaBeta.getCongresistas().add(nuevoCandidato(111, "Claudia Reyes Soto"));
		listaBeta.getCongresistas().add(nuevoCandidato(112, "Adrián Molina Pardo"));
		listaBeta.getCongresistas().add(nuevoCandidato(113, "Irene Lozano Marín"));
		listaBeta.getCongresistas().add(nuevoCandidato(114, "Sergio Blanco Vidal"));
		cantabria.getListasPresentadas().add(listaBeta);

		// Agrup. Gamma: borrador, sin candidatos
		ListaCongreso listaGamma = crearListaCongreso(crearAgrupacionElectores("Agrup. Gamma", "AG"), EstadoLista.BORRADOR,
				cantabria);
		cantabria.getListasPresentadas().add(listaGamma);

		List<Circunscripcion> circunscripciones = new ArrayList<>();
		circunscripciones.add(cantabria);

		ListaCircunscripcionesDTO dto = ListaCircunscripcionesAssembler.toDTO(circunscripciones);

		for (CircunscripcionListasDTO circ : dto.getCircunscripciones()) {

			System.out.println();
			System.out.println("Gestión de Listas Electorales");
			System.out.println("Proceso: Elecciones Generales 2027");
			System.out.println("Circunscripción: " + circ.getNombre());
			System.out.println("Escaños a elegir: " + circ.getEscanhosCongreso());
			System.out.println();
			System.out.println(String.format("%-18s %-7s %-22s %9s %10s  %-10s", "Candidatura", "Siglas",
					"Cabeza de lista", "Titulares", "Suplentes", "Estado"));

			for (ListaResumenDTO lista : circ.getListasCongreso()) {
				int total = lista.getCandidatos().size();
				int titulares = Math.min(total, circ.getEscanhosCongreso());
				int suplentes = total - titulares;
				String cabeza;
				if (total == 0) {
					cabeza = "(sin cabeza de lista)";
				} else {
					cabeza = lista.getCandidatos().get(0).getNombre();
				}
				System.out.println(String.format("%-18s %-7s %-22s %9d %10d  %-10s", lista.getCandidatura(),
						lista.getSiglas(), cabeza, titulares, suplentes, lista.getEstado()));
			} // for

			System.out.println();

		} // for

	} // testDTO

	private static Circunscripcion crearCircunscripcion(String nombre, int congresistas, int senadores) {

		Circunscripcion circunscripcion = new Circunscripcion();
		circunscripcion.setNombre(nombre);
		circunscripcion.setCongresistas(congresistas);
		circunscripcion.setSenadores(senadores);
		circunscripcion.setListasPresentadas(new LinkedHashSet<ListaElectoral>());
		return circunscripcion;

	} // crearCircunscripcion

	private static PartidoPolitico crearPartidoPolitico(String nombre, String siglas) {

		PartidoPolitico partido = new PartidoPolitico();
		partido.setNombre(nombre);
		partido.setSiglas(siglas);
		return partido;

	} // crearPartidoPolitico

	private static Coalicion crearCoalicion(String nombre, String siglas) {

		Coalicion coalicion = new Coalicion();
		coalicion.setNombre(nombre);
		coalicion.setSiglas(siglas);
		return coalicion;

	} // crearCoalicion

	private static AgrupacionElectores crearAgrupacionElectores(String nombre, String siglas) {

		AgrupacionElectores agrupacion = new AgrupacionElectores();
		agrupacion.setNombre(nombre);
		agrupacion.setSiglas(siglas);
		return agrupacion;

	} // crearAgrupacionElectores

	private static ListaCongreso crearListaCongreso(Candidatura candidatura, EstadoLista estado,
			Circunscripcion circunscripcion) {

		ListaCongreso lista = new ListaCongreso();
		lista.setCandidatura(candidatura);
		lista.setEstado(estado);
		lista.setPresentadaEn(circunscripcion);
		return lista;

	} // crearListaCongreso

	/**
	 * Caso de prueba para el Proxy.
	 *
	 */
	private static void testProxy() {

		System.out.println("Probando ListaCongresoProxy");
		System.out.println();
		ListaCongresoProxy lista = new ListaCongresoProxy();
		lista.setId(1L);

		List<DatosContacto> congresistas = lista.getCongresistas();
		System.out.println("Congresistas, carga perezosa: ");
		for (DatosContacto congresista : congresistas) {
			System.out.println("  " + congresista.getNombre());
		}

		congresistas = lista.getCongresistas();
		System.out.println("Congresistas, ya cargados: ");
		for (DatosContacto congresista : congresistas) {
			System.out.println("  " + congresista.getNombre());
		}
		System.out.println();

		Set<Impugnacion> impugnaciones = lista.getImpugnaciones();
		System.out.println("Impugnaciones, carga perezosa: ");
		for (Impugnacion impugnacion : impugnaciones) {
			System.out.println("  " + impugnacion.getMotivacion());
		} // for

		impugnaciones = lista.getImpugnaciones();
		System.out.println("Impugnaciones, ya cargados: ");
		for (Impugnacion impugnacion : impugnaciones) {
			System.out.println("  " + impugnacion.getMotivacion());
		} // for

	} // testProxy

} // Runner
