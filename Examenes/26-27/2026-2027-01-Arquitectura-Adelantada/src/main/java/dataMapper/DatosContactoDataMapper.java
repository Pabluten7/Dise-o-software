package dataMapper;

import java.util.ArrayList;
import java.util.List;

import domain.DatosContacto;
import exceptions.PersistenceException;

/**
 * Data Mapper para la entidad DatosContacto.
 */
public class DatosContactoDataMapper {

  /**
   * Recupera los congresistas de una lista al congreso, ordenados por posición.
   * Actualmente, devuelve una lista ficticia de congresistas.
   * 
   * @param listaId identificador de la lista al congreso
   * @throws PersistenceException si ocurre un error de persistencia
   */
  public List<DatosContacto> findCongresistasByListaId(long listaId)
      throws PersistenceException {
    return crearListaFicticia();
  } // findCongresistasByListaId

  /**
   * Recupera los senadores de una lista al senado, ordenados por posición.
   * Actualmente, devuelve una lista ficticia de senadores.
   * 
   * @param listaId identificador de la lista al senado
   * @throws PersistenceException si ocurre un error de persistencia
   */
  public List<DatosContacto> findSenadoresByListaId(long listaId)
      throws PersistenceException {
    return crearListaFicticia();
  } // findSenadoresByListaId

  private List<DatosContacto> crearListaFicticia() {

    List<DatosContacto> lista = new ArrayList<>();

    DatosContacto primero = new DatosContacto();
    primero.setId(1);
    primero.setNombre("Ana");
    primero.setPrimerApellido("Perez");
    primero.setSegundoApellido("Gomez");
    primero.setTelefono(600111222L);
    primero.setCorreoElectronico("ana.perez@example.com");
    lista.add(primero);

    DatosContacto segundo = new DatosContacto();
    segundo.setId(2);
    segundo.setNombre("Luis");
    segundo.setPrimerApellido("Garcia");
    segundo.setSegundoApellido("Lopez");
    segundo.setTelefono(600222333L);
    segundo.setCorreoElectronico("luis.garcia@example.com");
    lista.add(segundo);

    DatosContacto tercero = new DatosContacto();
    tercero.setId(3);
    tercero.setNombre("Marta");
    tercero.setPrimerApellido("Sanchez");
    tercero.setSegundoApellido("Ruiz");
    tercero.setTelefono(600333444L);
    tercero.setCorreoElectronico("marta.sanchez@example.com");
    lista.add(tercero);

    return lista;
  } // crearListaFicticia

} // DatosContactoDataMapper
