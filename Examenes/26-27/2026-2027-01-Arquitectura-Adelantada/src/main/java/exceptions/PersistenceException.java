package exceptions;

/***
 * Excepción que indica un error en la capa de persistencia, de manera 
 * independiente de la tecnología concreta utilizada.
 * 
 * @author Pablo Sanchez (sanchezbp)
 */
public class PersistenceException extends Exception {

  /**
   * Constructor de la clase PersistenceException.
   *
   * @param message Un mensaje descriptivo de la excepción.
   * @param e La excepción original que causa esta excepción.
   * 
   */
  public PersistenceException(String message, Exception e) {
    super(message,e);
  } // PersistenceException(String, Exception)

} // PersistenceException