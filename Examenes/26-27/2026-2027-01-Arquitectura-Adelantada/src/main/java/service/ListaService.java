package service;

import domain.DatosContacto;
import domain.ListaCongreso;
import domain.ResultadoInclusion;
import exceptions.PersistenceException;
import repositories.ListaElectoralRepository;

/**
 * Servicio para gestionar operaciones relacionadas con las listas electorales.
 */
public class ListaService {

  /**
   * Añade un candidato al final de una lista al congreso de una candidatura.
   * El candidato sólo se añade si la lista está en borrador.
   * 
   * @param listaId   Identificador de la lista al congreso.
   * @param candidato El candidato a añadir.
   * @return EXCLUIDO si no se pudo añadir, TITULAR o SUPLENTE según la
   *         posición ocupada.
   * @throws PersistenceException Si ocurre un error durante la persistencia.
   * @pre candidato != null
   */
  public ResultadoInclusion anhadirCandidato(long listaId,
      DatosContacto candidato) throws PersistenceException {

    // Cambios realizados en el modelo de dominio:
    // (1) DatosContacto: nuevo atributo id, necesario para identificar al
    // candidato.
    // (2) ListaElectoral: nuevo atributo id (para buscarla).
    // (4) Nuevo enumerado ResultadoInclusion {EXCLUIDO, TITULAR, SUPLENTE}.
    // (5) ListaCongreso: nuevo método addCandidato, que comprueba el estado
    // BORRADOR, añade al final y calcula si es titular o suplente.
    // (6) Nuevo repositorio ListaElectoralRepository con findListaCongresoById

    ResultadoInclusion result = ResultadoInclusion.EXCLUIDO;

    try {

      ListaCongreso lista = ListaElectoralRepository.findListaCongresoById(listaId);

      if (lista != null) {

        // Se abre la transacción creando una nueva unidad de trabajo
        result = lista.addCandidato(candidato);

        // Se registraría en la unidad de trabajo como objeto nuevo el
        // candidato (DatosContacto), si no existía previamente, y como
        // objeto modificado la lista (ListaCongreso), cuya colección
        // congresistas ha cambiado.

        // Se cierra la transacción, invocando el commit de la unidad de trabajo

      } // if

    } catch (Exception e) {
      // Se abortaría la transacción, invocando el rollback de la unidad de trabajo
      throw new PersistenceException("Error al añadir un candidato a la lista", e);
    } // catch

    return result;

  } // anhadirCandidato

} // ListaService
