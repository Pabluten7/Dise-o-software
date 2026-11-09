package databaseConnection;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.Stack;
import exceptions.PersistenceException;

/** 
 * Clase que implementa un pool de conexiones a base de datos.
 * 
 * @author sanchezbp
 */
public class DbConnectionPool {
	
	protected Stack<Connection> pool = new Stack<Connection>();
	
	protected static int POOL_SIZE = 10;
	
	protected static DbConnectionPool theInstance;
	
	public static void setPoolSize(int size) {
		POOL_SIZE = size;
	}
	
	/**
	 * Constructor protegido para el pool de conexiones.
	 * 
	 * @throws PersistenceException Excepcion de persistencia generada durante la creacion del pool de conexiones.
	*/
	protected DbConnectionPool() throws PersistenceException {
		feedPool();
	} // DbConnectionPool

	/**
	 * Rellena el pool de conexiones.
	 * 
	 * @throws PersistenceException Excepcion de persistencia generada durante la creacion de conexiones para el pool.
	 */
	protected void feedPool() throws PersistenceException {
		for(int i=0;i<POOL_SIZE;i++) {
			try {
				pool.push(DbConnectionHelper.createConnection());
			} catch (SQLException e) {
				throw new PersistenceException("Error creando conexiones para el pool de conexiones.", e);
			} // try-catch
		} // for
	} // feedPool
	
	/**
	 * Obtiene la instancia unica del pool de conexiones.
	 * 
	 * @return la instancia unica del pool de conexiones.
	 * @throws PersistenceException Excepcion SQL generada durante la obtencion de la instancia del pool de conexiones.
	 */
	public static DbConnectionPool getInstance() throws PersistenceException 
	{
		if (theInstance == null) {
			theInstance = new DbConnectionPool();
		} // if
		return theInstance;
	} // getInstance
	
	/**
	 * Obtiene una conexion del pool de conexiones.
	 * 
	 * @return una conexion del pool de conexiones.
	 * @throws PersistenceException Excepcion SQL generada durante la obtencion de una conexion del pool.
	 */ 
	public Connection getConnection() throws PersistenceException {
	
		if (pool.empty()) {
			feedPool();			
		} // if
		return pool.pop();
	} // getConnection
	
	/**
	 * Devuelve una conexion al pool de conexiones.
	 * 
	 * @param c la conexion a devolver al pool de conexiones. 	
	 * @throws PersistenceException Excepcion SQL generada durante la devolucion de una conexion al pool.
	*/
	public void returnConnection(Connection c) throws PersistenceException {
		
		if (pool.size() < POOL_SIZE) {
			pool.push(c);
		} else {
			try {
				c.close();
			} catch (SQLException e) {
				throw new PersistenceException("Error cerrando la conexion devuelta al pool de conexiones.", e);
			} // try-catch	
		} //if
	} // returnConnection
	
} // DBConnectionPool
